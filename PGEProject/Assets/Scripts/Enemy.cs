using UnityEngine;

public class Enemy : Interactable
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float knockbackDuration = 0.5f;
    float knockbackTimer;
    bool isDead = false;
    Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Pause enemy movement while getting hit by player
        if(knockbackTimer > 0f)
        {
            knockbackTimer -= Time.deltaTime;
            return;
        }

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

        UIManager.Instance.UpdateEnemyRemaining();
    }

    public void SetLevel(int level)
    {
        // Every 2 levels +20hp
        health += (level / 2) * 20f;

        // Every 3 levels +1 move speed
        moveSpeed += (level / 3) * 1f;
    }

    protected override void Interact()
    {
        // Push enemy from where player is looking
        Vector3 direction = Camera.main.transform.forward;
        direction.y = 0f;
        direction.Normalize();

        knockbackTimer = knockbackDuration;
        rb.linearVelocity = Vector3.zero;

        // Force mode ignore enemy's mass
        rb.AddForce(direction * GameManager.Instance.knockback, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Die();
        }
    }
}
