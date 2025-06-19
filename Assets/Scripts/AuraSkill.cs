using UnityEngine;

public class AuraSkill : MonoBehaviour
{
    [SerializeField] float damage = 1f;  
    [SerializeField] float radius = 3.5f;
    [SerializeField] float rotationSpeed = 90f;

        Transform player;

    void Start()
    {
        GetComponent<CircleCollider2D>().radius = radius;
        player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (player.localScale.x >= 0)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        else 
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                if (Time.frameCount % 60 == 0)
                { enemy.TakeDamage(damage); }
            }
        }
    }
}
