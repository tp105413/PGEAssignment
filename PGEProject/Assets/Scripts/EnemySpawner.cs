using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawners;

    public float spawnEnemyTimer = 20f;
    public float spawnInterval = 16f;


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isWaveRunning) return;

        // Nothing to spawn
        if (GameManager.Instance.enemyCount <= 0) return;

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
        GameObject obj = Instantiate(enemyPrefab, spawner.position, spawner.rotation);
        GameManager.Instance.enemyCount--;
        Enemy enemy = obj.GetComponent<Enemy>();

        // After spawn enemy set its stats
        enemy.SetLevel(GameManager.Instance.level);
    }

    public void SpawnNextEnemy()
    {
        // Keep the pace for tutorial
        if (GameManager.Instance.level == 0) return;
        if (!GameManager.Instance.isWaveRunning) return;
        if (GameManager.Instance.enemyCount <= 0) return;

        SpawnEnemy();

        // Restart enemy spawn countdown
        spawnEnemyTimer = spawnInterval;
    }
}
