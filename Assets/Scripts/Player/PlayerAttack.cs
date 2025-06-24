using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] float fireOffsetX = 0.8f;
    [SerializeField] float fireOffsetY = 0f;
    [SerializeField] float fireInterval = 1f;
    PlayerStats playerStats;

    Animator animator;

    float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            Fire();
            timer = 0f;
        }
    }

    void Fire()
    {
        Vector2 origin = transform.position;
        var directions = playerStats.GetSkill(playerStats.skillLevel);

        foreach (var dir in directions)
        {
            GameObject fireball = ObjectPooler.Instance.SpawnFromPool("fireball", origin, Quaternion.identity);
            fireball.GetComponent<FireBall>().SetDirection(dir);

            if (dir == Vector2.right)
            {
                Vector3 scale = fireball.transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                fireball.transform.localScale = scale;
            }

            if (playerStats.skillLevel >= 3)
            {
                fireball.transform.localScale *= 3f;
            }
        }
    }

}