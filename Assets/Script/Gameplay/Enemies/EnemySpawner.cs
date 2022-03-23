using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform _spawnParent;
    public List<GameObject> enemySpawner = new List<GameObject>();


    [SerializeField]float spawnRate = 2.0f;
    [SerializeField]float nextSpawn = 0;
    float randx;
    float randy;

    public int _desiredEnemies = 5;
    private bool _canSpawn = true;
    public static int _totalEnemies = 0;


    Vector2 whereToSpawn;

    private void Update()
    {
        UpdateSpawnTimer();
        SpawnDesiredEnemies();
    
    }

    private void UpdateSpawnTimer()
    {
        //only progress if can't currently spawn
        if (!_canSpawn)
        {
            if (nextSpawn >= spawnRate)
            {
                //spawn new enemies
                _canSpawn = true;
                nextSpawn = 0.0f;
            }

            //Update time since last spawn

            nextSpawn += Time.deltaTime;
        }
    }


    private void SpawnDesiredEnemies()
    {
        if (_totalEnemies < _desiredEnemies)
        {
            //Can enemy spawned
            if (_canSpawn)
            {
                //Spawn random Enemy
                SpawnRandomEnemy();

                //Disable spawning
                _canSpawn = false;
            }

        }
    }

    void SpawnRandomEnemy()
    {
        int pickEnemy = Random.Range(0, enemySpawner.Count);

        randx = Random.Range(1, 1);
        randy = Random.Range(1, 1);

        whereToSpawn = new Vector2(randx, randy);

        Instantiate(enemySpawner[pickEnemy], whereToSpawn, Quaternion.identity, _spawnParent);

        _totalEnemies++;
    }
}
