// Scripts/Projectile/HomingMissile.cs
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float seekRadius = 10f;
    [SerializeField] float offsetX = 0.8f;
    [SerializeField] float offsetY = 0f;

    Transform target;
    float timer;
    float maxLifetime = 6f; // 미사일 지속 시간 제한

    void OnEnable()
    {
        timer = 0f;
        FindClosestEnemy();

        // 발사 위치 조정
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            bool isFacingRight = player.transform.localScale.x > 0;
            Vector3 offset = new Vector3(isFacingRight ? offsetX : -offsetX, offsetY, 0);
            transform.position = player.transform.position + offset;

            if (!isFacingRight)
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= maxLifetime)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(2f); // 필요시 데미지 조정
            }
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = seekRadius;
        Transform closest = null;

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy.transform;
            }
        }

        target = closest;
    }
}
