using UnityEngine;
using TMPro;

public class KillLog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killText;

    int killCount;

    public static KillLog Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        UpdateKillText();
    }

    public void AddKill()
    {
        killCount++;
        UpdateKillText();
    }

    void UpdateKillText()
    {
        killText.text = $"{killCount}";
    }
}