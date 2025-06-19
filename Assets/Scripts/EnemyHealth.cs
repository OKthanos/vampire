using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 3f;
    [SerializeField] float experience;
    [SerializeField] GameObject gemPrefab;
    float currentHealth;
    void Start()
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
            Instantiate(gemPrefab, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        GameManager.Instance.KillCount();
    }

}
