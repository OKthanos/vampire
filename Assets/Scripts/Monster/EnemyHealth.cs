// Scripts/Enemy/EnemyHealth.cs
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 3f;
    [SerializeField] float experience = 5f;
    [SerializeField] GameObject gemPrefab;

    float currentHealth;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gemPrefab != null)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            // Gem은 필요 시 ObjectPool로 교체 가능
        }

        GameManager.Instance.AddXP(experience);
        GameManager.Instance.KillCount();

        // 적을 없애지 않고 풀로 되돌리려면 여기를 수정
        Destroy(gameObject);
    }
}
