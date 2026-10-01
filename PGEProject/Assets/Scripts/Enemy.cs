using UnityEngine;

public class Enemy : Interactable
{
    public float health = 100f;
    public float moveSpeed = 3f;

    Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 targetZone = new Vector3(0, transform.position.y, 0);
        Vector3 direction = (targetZone - transform.position).normalized;

        rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddSun();
        Destroy(gameObject);
    }
}
