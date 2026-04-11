using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private enum AIState
    {
        Run,
        Hide,
        Death
    }
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    private NavMeshAgent _agent;
    private int _id;
    private GameManager _gameManager;
    [SerializeField] private AIState _aIState;
    private Animator _animator;

    private UIManager _uIManager;

    private bool _reachedBarrier = false;
    private bool _leftBarrier = false;
    private float _speed = 0f;
    void Start()
    {
        AssigningVariables();
        InitializingVariables();
       
        if (_id < 10)
        {
            _agent.isStopped = false;
        }

        GoToBarrier();
    }

    private void AssigningVariables()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _endPoint = GameObject.Find("EndPoint").transform.Find("Point_B");

        _agent = GetComponent<NavMeshAgent>();

        _animator = GetComponent<Animator>();

        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void InitializingVariables()
    {
        _agent.speed = 5f;
        _agent.isStopped = true;
        _animator.SetFloat("Speed", 0f);
    }

    void Update()
    {   
        EnableMovement();
        ManageAIState();

        if (!_agent.pathPending && _agent.remainingDistance < 0.5f && _reachedBarrier == false)
        {
            _reachedBarrier = true;
            _agent.isStopped = true;
            StartCoroutine(HideAndWait());
        }
        CheckEnemyEscaped();
    }

    private void GoToBarrier()
    {
        GameObject[] barriers = _gameManager.GetBarriers();
        _agent.destination = barriers[Random.Range(0,barriers.Length)].transform.position;
    }

    private void ManageAIState()
    {
        switch (_aIState)
        {
            case AIState.Run:
                Debug.Log("Running");
                IncreaseSpeed();
                break;
            case AIState.Hide:
                Debug.Log("Hiding");
                break;
            case AIState.Death: 
                Debug.Log("Dead");
                StartCoroutine(Death());
                break;
        }
    }
    private void CheckEnemyEscaped()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 0.5 && _leftBarrier == true)
        {
            _gameManager.AddToGoneEnemies();
            Destroy(gameObject);
        }
    }

    public void SetAIStateToDeath()
    {
        _aIState = AIState.Death;
        _gameManager.AddToGoneEnemies();
        _uIManager.AddToPoints(50);
    }

    private IEnumerator Death()
    {
        _agent.isStopped = true;
        _animator.SetTrigger("Death");
        
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void IncreaseSpeed()
    {
        if (_agent.isStopped == false && _speed <= 5)
        {
            _speed += 1.0f * Time.deltaTime;
            _animator.SetFloat("Speed", _speed);
        }
    }
    private void EnableMovement()
    {
        if (_gameManager.GetGoneEnemies() == 10 && _id < 20)
        {
            _agent.isStopped = false;
        }
        else if (_gameManager.GetGoneEnemies() == 20 && _id < 30)
        {
            _agent.isStopped = false;
        }
    }

    public void SetEnemyID(int id)
    {
        _id = id;
    }

    IEnumerator HideAndWait()
    {
        _animator.SetBool("Hiding", true);
        yield return new WaitForSeconds(11f);
        _agent.destination = _endPoint.position;
        _animator.SetBool("Hiding", false);
        _agent.isStopped = false;
        yield return new WaitForSeconds(1f);
        _leftBarrier = true;
    }

}
