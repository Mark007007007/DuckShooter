using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    private NavMeshAgent _agent;
    private int _id;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_startPoint = GameObject.Find("StartPoint").transform.Find("Point_A");
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _endPoint = GameObject.Find("EndPoint").transform.Find("Point_B");

        _agent = GetComponent<NavMeshAgent>();

        _agent.destination = _endPoint.position;
        _agent.isStopped = true;
        if (_id < 10)
        {
            _agent.isStopped = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 0.5)
        {
            Debug.Log(_id);
            _gameManager.AddToGoneEnemies();
            Destroy(gameObject);
        }
        else if (_gameManager.GetGoneEnemies() == 10 && _id < 20)
        {
            _agent.isStopped = false;
        }
        else if (_gameManager.GetGoneEnemies() == 20 && _id < 30)
        {
            _agent.isStopped = false;
        }
    }

    public void StartMoving()
    {
        _agent.isStopped = true;
    }

    public void SetEnemyID(int id)
    {
        _id = id;
    }// point_A and point_B very far from each other, enemies spawn near point_A and go towards point_B, but that debug.log above is getting called when it is near point_A

}
