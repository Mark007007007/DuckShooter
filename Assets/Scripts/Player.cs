using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 _targetPosition;
    float _distance;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = 0f;
        _distance = Vector3.Distance(transform.position, _targetPosition);

        if (_distance > 1f)
        {
            direction = (_targetPosition - transform.position).normalized;
            direction.y = 0f;
            transform.Translate(direction * Time.deltaTime * 3f);
        }
    }

    public void Movement(Vector3 pos)
    {
        _targetPosition = pos;
    }
    // when I press it once it is going their, but second time it is going somewhere far away
}
