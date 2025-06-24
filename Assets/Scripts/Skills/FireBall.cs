// Scripts/Projectile/FireBall.cs
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] Vector2 moveDirection = Vector2.right;
    [SerializeField] float damage = 3f;

    float timer;
    PlayerStats playerStats;

    void OnEnable()
    {
        timer = 0f;
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage * playerStats.GetDamage());
            }
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }
    }
}
