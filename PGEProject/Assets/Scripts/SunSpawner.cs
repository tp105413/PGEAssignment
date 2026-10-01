using UnityEngine;
using UnityEngine.Pool;

public class SunSpawner : MonoBehaviour
{
    public GameObject sunPrefab;

    float spawnSunTimer = 5f;

    ObjectPool<Collectible> sunPool;


    void Awake()
    {
        sunPool = new ObjectPool<Collectible>(CreateSun, OnGetSun, OnReleaseSun);

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isWaveRunning) return;

        if (spawnSunTimer < 0f)
        {
            // Ask sun pool to get sun prefab
            SpawnSun();
            spawnSunTimer = Random.Range(8, 10);
        }
        else
        {
            spawnSunTimer -= Time.deltaTime;
        }
    }

    Collectible SpawnSun()
    {
        Collectible sun = sunPool.Get();

        sun.transform.SetPositionAndRotation(new Vector3(Random.Range(transform.position.x, transform.position.x + 50),
                        transform.position.y + 15, Random.Range(transform.position.z, transform.position.z + 50)),
                        Quaternion.identity);

        return sun;
    }

    public Collectible CreateSun()
    {
        Collectible sun = Instantiate(sunPrefab.GetComponent<Collectible>());
        sun.SetSunPool(sunPool);
        return sun;
    }

    public void OnGetSun(Collectible sun)
    {
        sun.gameObject.SetActive(true);
    }

    public void OnReleaseSun(Collectible sun)
    {
        sun.gameObject.SetActive(false);
    }
}
