// Scripts/Mono/Player/PlayerBehaviour.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    PlayerCore core;
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] PlayerStats stats;
    [SerializeField] float maxHealth = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        core = new PlayerCore(stats, maxHealth);
    }

    void Update()
    {
        Vector2 input = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        core.MoveDirection = input;

        bool isMoving = input.magnitude > 0f;
        animator.SetBool("isMoving", isMoving);

        if (input.x != 0f)
        {
            Vector3 scale = transform.localScale;
            scale.x = input.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = core.MoveDirection * core.GetSpeed();
    }

    public void TakeDamage(float amount)
    {
        core.TakeDamage(amount);
        animator.SetTrigger("TakeHit");

        if (core.IsDead)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<Collider2D>().enabled = false;
        rb.simulated = false;

        GameManager.Instance.GameOver();
    }
}
