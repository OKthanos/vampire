using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        bool isMoving = moveInput.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        if (moveInput.x != 0)
        {
            Vector2 scale = transform.localScale;
            if (moveInput.x > 0)
            {
                scale.x = 1;
            }
            else
            {
                scale.x = -1;
            }
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}