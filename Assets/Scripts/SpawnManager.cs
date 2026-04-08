using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    private GameObject enemy;
    [SerializeField] Transform _spawnPos;
    private AI _ai;

    void Start()
    {
       for (int i = 0; i < _enemies.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                enemy = Instantiate(_enemies[i], _spawnPos.position, Quaternion.identity);
                enemy.GetComponent<AI>().SetEnemyID(i * 10 + j);
                Debug.Log("hello: " + i);
            }
        }
    }
}
