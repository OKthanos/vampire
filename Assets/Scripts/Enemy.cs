using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float damage = 1f;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 scale = transform.localScale;
            if (target.position.x > transform.position.x)
            {
                scale.x = -1;
            }
            else
            {
                scale.x = 1;
            }
            transform.localScale = scale;
        if (target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            Vector2 newPos = rb.position + dir * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPos);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
