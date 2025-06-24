using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("XP & Level")]
    [SerializeField] Slider xpBar;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] LevelUpUI levelUpUI;

    float currentXP;
    [SerializeField] float maxXP = 100f;
    float level = 1;

    [Header("Status")]
    public bool isGameOver = false;
    [SerializeField] TextMeshProUGUI killCountText;
    float killCount = 0;

    [Header("Pooling Targets")]
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] int fireballPoolSize = 20;

    [SerializeField] GameObject homingMissilePrefab;
    [SerializeField] int missilePoolSize = 10;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InitializeXPUI();
        InitializeObjectPools();
    }

    void InitializeXPUI()
    {
        xpBar.maxValue = maxXP;
        xpBar.value = currentXP;
        levelText.text = $"Lv. {level}";
    }

    void InitializeObjectPools()
    {
        ObjectPooler.Instance.CreatePool(fireballPrefab, fireballPoolSize, "fireball");
        ObjectPooler.Instance.CreatePool(homingMissilePrefab, missilePoolSize, "missile");
        Debug.Log("Object Pools Initialized");
    }

    public void AddXP(float amount)
    {
        currentXP += amount;
        xpBar.value = currentXP;

        if (currentXP >= maxXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXP -= maxXP;
        maxXP = Mathf.RoundToInt(maxXP * 1.2f);

        xpBar.maxValue = maxXP;
        xpBar.value = currentXP;
        levelText.text = $"Lv. {level}";

        levelUpUI.Show();
    }

    public void KillCount()
    {
        killCount++;
        killCountText.text = $": {killCount}";
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }
}
