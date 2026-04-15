using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _strength = 3;
    void Update()
    {
        if (_strength <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("You Destroyed A Berrier");
        }
    }

    public void TakeDamage()
    {
        _strength --;
        Debug.Log("u damaged the Barrier");
    }
}
