using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float flySpeed;

    bool released;

    IObjectPool<Bullet> bulletPool;


    void OnEnable()
    {
        released = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (released) return;

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();

            if(enemy != null)
            {
                enemy.TakeDamage(20);
                ReleaseBullet();
            }
        }
        else if (other.CompareTag("Wall"))
        {
            ReleaseBullet();
        }
    }

    public void SetBulletPool(IObjectPool<Bullet> newPool)
    {
        bulletPool = newPool;
    }

    public void ReleaseBullet()
    {
        if (released) return;
        released = true;

        bulletPool.Release(this);
    }
}
