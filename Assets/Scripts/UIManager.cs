using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] int _points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToPoints(int point)
    {
        _points += point;
        Debug.Log(_points);
    }
}
