using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] float xpValue = 5f;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddXP(xpValue);
            Destroy(gameObject);
        }
    }

}
