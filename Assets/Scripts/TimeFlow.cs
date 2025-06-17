using UnityEngine;
using TMPro;

public class TimeFlow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    float elapsedTime;


    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minute = Mathf.FloorToInt(elapsedTime / 60f);
        int second = Mathf.FloorToInt(elapsedTime % 60f);
        timeText.text = $"{minute:00}:{second:00}";   
    }
}
