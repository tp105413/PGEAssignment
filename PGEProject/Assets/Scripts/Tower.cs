using UnityEngine;
using UnityEngine.Pool;

public enum FirePattern { Forward, Straight, Cross }

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireInterval = 1.4f;
    public FirePattern firePattern;

    float spawnBulletTimer;
    public Vector3 spawnOffset = new Vector3(0, 1f, 1f);

    ObjectPool<Bullet> bulletPool;


    void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isWaveRunning) return;

        if (spawnBulletTimer < 0f)
        {
            FireBullet();
            spawnBulletTimer = fireInterval;
        }
        else
        {
            spawnBulletTimer -= Time.deltaTime;
        }
    }

    void SpawnBullet(float direction)
    {
        Bullet bullet = bulletPool.Get();

        Vector3 spawnPosition = transform.position + transform.rotation * spawnOffset;
        Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, direction, 0);

        bullet.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
    }

    public Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab.GetComponent<Bullet>());
        bullet.SetBulletPool(bulletPool);
        return bullet;
    }

    public void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void FireBullet()
    {
        switch (firePattern)
        {
            case FirePattern.Forward:
                SpawnBullet(0f);
                break;
            case FirePattern.Straight:
                SpawnBullet(0f);
                SpawnBullet(180f);
                break;
            case FirePattern.Cross:
                SpawnBullet(55f);
                SpawnBullet(125f);
                SpawnBullet(235f);
                SpawnBullet(305f);
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
