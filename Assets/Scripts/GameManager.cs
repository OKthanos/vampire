using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("XP")]
    [SerializeField] Slider xpBar;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] LevelUpUI levelUpUI;

    float currentXP;
    [SerializeField] float maxXP = 100;
    float level = 1;
    float killCount = 0;

    [Header("Status")]
    public bool isGameOver = false;
    [SerializeField] TextMeshProUGUI killCountText;

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
        xpBar.maxValue = maxXP;
        xpBar.value = currentXP;
        levelText.text = $"Lv.{level}";
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
        killCount ++;
        killCountText.text = $": {killCount}";
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }
}