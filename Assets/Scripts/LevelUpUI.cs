using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;
    [SerializeField] Button[] optionButtons;
    [SerializeField] TextMeshProUGUI[] optionTexts;

    List<string> allOptions = new() { "Attack Upgrade", "Move Speed Upgrade", "HP Upgrade", "Skill Upgrade", "Cooltime Decrease"};
    string[] currentChoices;
    PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtons[i].onClick.AddListener(() => SelectOption(index));
        }

        Hide();
    }

    public void Show()
    {
        uiPanel.SetActive(true);
        Time.timeScale = 0f;

        currentChoices = GetRandomOptions(3);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionTexts[i].text = currentChoices[i];
        }
    }

    string[] GetRandomOptions(int count)
    {
        List<string> pool = new(allOptions);
        List<string> result = new();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int rand = Random.Range(0, pool.Count);
            result.Add(pool[rand]);
            pool.RemoveAt(rand);
        }

        return result.ToArray();
    }

    void SelectOption(int index)
    {
        string selected = currentChoices[index];
        playerStats.Upgrade(selected); 
        Debug.Log("Skill: " + selected);
        Hide();
    }

    void Hide()
    {
        uiPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
