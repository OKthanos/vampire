using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float seekRadius = 10f;
    [SerializeField] float offsetX = 0.8f; // 좌우 거리 조절
    [SerializeField] float offsetY = 0f;

    Transform target;

    void Start()
    {
        // 발사 위치 및 방향 설정
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // 플레이어 방향 판별
            bool isFacingRight = player.transform.localScale.x > 0;

            // 발사 위치 보정
            Vector3 offset = new Vector3(isFacingRight ? offsetX : -offsetX, offsetY, 0);
            transform.position = player.transform.position + offset;

            // 미사일 방향 반전
            if (!isFacingRight)
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        // 타겟 탐색
        FindClosestEnemy();
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime);
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