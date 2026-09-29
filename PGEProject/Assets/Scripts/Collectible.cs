using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed;
    public float dropSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);

        if(transform.position.y > 0.5f)
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
            Destroy(gameObject);
        }
    }
}
