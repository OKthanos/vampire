using UnityEngine;

public class PlayerMissileShooter : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float fireInterval = 2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            FireMissile();
            timer = 0f;
        }
    }

    void FireMissile()
    {
        Instantiate(missilePrefab, transform.position, Quaternion.identity);
    }
}