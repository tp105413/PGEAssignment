using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float flySpeed;

    IObjectPool<Bullet> bulletPool;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HitTarget();
        }
        else if (other.CompareTag("Wall"))
        {
            HitTarget();
        }
    }

    public void SetBulletPool(IObjectPool<Bullet> newPool)
    {
        bulletPool = newPool;
    }

    public void HitTarget()
    {
        bulletPool.Release(this);
    }
}
