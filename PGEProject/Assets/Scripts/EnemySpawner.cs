using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawners;

    public float spawnEnemyTimer = 20f;
    public float spawnInterval = 16f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isWaveRunning) return;

        if (spawnEnemyTimer < 0f)
        {
            SpawnEnemy();
            spawnEnemyTimer = spawnInterval;
        }
        else
        {
            spawnEnemyTimer -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawners.Length);

        Transform spawner = spawners[randomIndex];
        Instantiate(enemyPrefab, spawner.position, spawner.rotation);
    }
}
