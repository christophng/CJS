using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TMP_Text timerText;
    private TimerManager timerManager;

    private void Start()
    {
        timerManager = TimerManager.GetInstance();
    }

    void Update()
    {
        // Update Text with timer value
        if (timerManager != null)
        {
            float timerValue = timerManager.GetTimerValue();
            string formattedTime = FormatTime(timerValue);
            timerText.text = "Time: " + formattedTime;
        }
    }

    // Format "mm:ss"
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
