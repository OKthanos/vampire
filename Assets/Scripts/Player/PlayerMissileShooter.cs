// Scripts/Player/PlayerMissileShooter.cs
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
        ObjectPooler.Instance.SpawnFromPool("missile", transform.position, Quaternion.identity);
    }
}
