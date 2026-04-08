using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class OldAI : MonoBehaviour
{
    private enum AIState
    {
        Walking,
        Jumping,
        Attacking,
        Death
    }
    [SerializeField] private GameObject[] _wayPoints;
    private NavMeshAgent _ai;
    private int _pointId = 0;
    private bool _isReversed = false;
    [SerializeField] private AIState _aIState;
    void Start()
    {
        _ai = GetComponent<NavMeshAgent>();
        _ai.destination = _wayPoints[_pointId].transform.position;
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _aIState = AIState.Jumping;
            _ai.isStopped = true;
        }

        switch (_aIState)
        {
            case AIState.Walking:
            Debug.Log("Walking");
            CalculateAIMovement();
                break;
            case AIState.Jumping:
            Debug.Log("Jumping");
                break;
            case AIState.Attacking:
            Debug.Log("Attacking");
            break;
            case AIState.Death:
            Debug.Log("Death");
            break;
        }
    }

    private void CalculateAIMovement()
    {
        if (_ai.remainingDistance < 0.5f)
        {
            _ai.isStopped = true;

            ChangeDestination();

            _ai.destination = _wayPoints[_pointId].transform.position;

            _aIState = AIState.Attacking;
            StartCoroutine(WaitTillWalking());
        }
    }

    private void ChangeDestination()
    {
        if (_isReversed == false && _pointId < _wayPoints.Length - 1)
        {
            _pointId ++;
        }
        else if (_isReversed == true && _pointId > 0)
        {
            _pointId --;
        }
        else
        {
            ToggleIsReversed();
        }
    }

    private void ToggleIsReversed()
    {
        if (_isReversed == true)
        {
            _isReversed = false;
        }
        else
        {
            _isReversed = true;
        }
            
    }

    IEnumerator WaitTillWalking()
    {
        yield return new WaitForSeconds(3f);
        _aIState = AIState.Walking;
        _ai.isStopped = false;
    }
}
