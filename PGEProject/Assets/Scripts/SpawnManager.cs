using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject sunPrefab;

    float spawnSunTimer = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isWaveRunning) return;

        if(spawnSunTimer < 0f)
        {
            SpawnSun();
            spawnSunTimer = Random.Range(8, 10);
        }
        else
        {
            spawnSunTimer -= Time.deltaTime;
        }
    }

    void SpawnSun()
    {
        Instantiate(sunPrefab, new Vector3(Random.Range(transform.position.x, transform.position.x + 50),
                        transform.position.y, Random.Range(transform.position.z, transform.position.z + 50)),
                        Quaternion.identity);
    }
}
