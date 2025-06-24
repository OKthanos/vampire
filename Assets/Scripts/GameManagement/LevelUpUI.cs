// Scripts/UI/LevelUpUI.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;
    [SerializeField] Button[] optionButtons;
    [SerializeField] TextMeshProUGUI[] optionTexts;

    [SerializeField] PlayerStats playerStats;

    List<string> allOptions = new()
    {
        "Attack Upgrade", "Move Speed Upgrade", "HP Upgrade", "Skill Upgrade", "Cooltime Decrease"
    };

    string[] currentChoices;

    void Start()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtons[i].onClick.AddListener(() => SelectOption(index));
        }

        Hide();
    }

    public void Show()
    {
        Time.timeScale = 0f;
        uiPanel.SetActive(true);

        currentChoices = GetRandomOptions(3);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionTexts[i].text = currentChoices[i];
        }
    }

    void SelectOption(int index)
    {
        string selected = currentChoices[index];
        playerStats.Upgrade(selected);
        Debug.Log("Level Up: " + selected);

        Hide();
    }

    void Hide()
    {
        Time.timeScale = 1f;
        uiPanel.SetActive(false);
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
}
