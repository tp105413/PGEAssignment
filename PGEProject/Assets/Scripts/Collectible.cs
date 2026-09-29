using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed;
    public float dropSpeed;

    public UnityEvent OnSunCollected;
    
    IObjectPool<Collectible> sunPool;


    void OnEnable()
    {
        OnSunCollected.AddListener(GameManager.Instance.AddSun);
    }

    void OnDisable()
    {
        OnSunCollected.RemoveListener(GameManager.Instance.AddSun);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
