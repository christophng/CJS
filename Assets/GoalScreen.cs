using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalScreen : MonoBehaviour
{
    public TMP_Text timerText;
    private TimerManager timerManager;
    public GameObject goalScreenPrefab;

    private void Start()
    {
        // Get the instance of the TimerManager
        timerManager = TimerManager.GetInstance();

        // Hide the goal screen UI when the game starts
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("UPDATING");
        // Update the UI Text with the timer value
        if (timerManager != null)
        {
            float timerValue = timerManager.GetTimerValue();
            string formattedTime = FormatTime(timerValue);
            timerText.text = "Time: " + formattedTime;
        }
    }

    public void SpawnGoalScreen()
    {
        Debug.Log("SPAWNING");
        GameObject goalScreenInstance = Instantiate(goalScreenPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Format the timer value as a string in the format "mm:ss"
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowGoalScreen()
    {
        Debug.Log("SHOWING");
        gameObject.SetActive(true);
        SpawnGoalScreen();
    }

    public void HideGoalScreen()
    {
        Debug.Log("HIDING");
        gameObject.SetActive(false);
    }

    public void OnGoalButtonClick()
    {
        HideGoalScreen();
        ResetButton reset = new ResetButton();
        reset.OnResetButtonClick();
        gameObject.SetActive(false);
    }
}
