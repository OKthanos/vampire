using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] Vector2 moveDirection = Vector2.right;
    [SerializeField] float damage = 3f;
    PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {                
                enemy.TakeDamage(damage * playerStats.GetDamage());
            }
            Destroy(gameObject);
        }
    }
}
