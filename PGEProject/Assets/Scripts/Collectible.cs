using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed;
    public float dropSpeed;
    public float lifeTime = 100f;

    float lifeTimer;
    bool released;

    public UnityEvent OnSunCollected;
    
    IObjectPool<Collectible> sunPool;


    void OnEnable()
    {
        OnSunCollected.AddListener(GameManager.Instance.AddSun);

        lifeTimer = lifeTime;
        released = false;
    }

    void OnDisable()
    {
        OnSunCollected.RemoveListener(GameManager.Instance.AddSun);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);

        if(transform.position.y > 1f)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= dropSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Release the sun if not pick up in 100 secs
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f)
        {
            ReleaseSun();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectSun();
        }
    }

    public void SetSunPool(IObjectPool<Collectible> newPool)
    {
        sunPool = newPool;
    }

    public void CollectSun()
    {
        OnSunCollected.Invoke();
        sunPool.Release(this);
    }

    void ReleaseSun()
    {
        if (released) return;
        released = true;
        sunPool.Release(this);
    }
}
