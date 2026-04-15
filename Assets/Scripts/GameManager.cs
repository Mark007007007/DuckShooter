using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private int _goneEnemies = 0;
    private GameObject[] _barriers;
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        _barriers = GameObject.FindGameObjectsWithTag("Barrier");
    }

    public void AddToGoneEnemies()
    {
        _goneEnemies ++;
    }

    public int GetGoneEnemies()
    {
        return _goneEnemies;
    }

    public GameObject[] GetBarriers()
    {
        return _barriers;
    }
}
