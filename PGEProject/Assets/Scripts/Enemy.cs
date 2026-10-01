using UnityEngine;

public class Enemy : Interactable
{
    public float health = 100f;
    public float moveSpeed = 3f;

    bool isDead = false;
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
        // Prevent double bullect call Die() at the same time
        if(isDead) return;

        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        GameManager.Instance.AddSun();
        GameManager.Instance.EnemiesDied();
        Destroy(gameObject);

        UIManager.Instance.UpdateGeneralUI();
    }

    public void SetLevel(int level)
    {
        // Every 2 levels +20hp
        health += (level / 2) * 20f;

        // Every 3 levels +1 move speed
        moveSpeed += (level / 3) * 1f;
    }
}
