using UnityEngine;

public class PlayerAuraSpawner : MonoBehaviour
{
    [SerializeField] GameObject auraPrefab;

    void Start()
    {
        Instantiate(auraPrefab, transform.position, Quaternion.identity, transform);
    }
}