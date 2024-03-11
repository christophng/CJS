using UnityEngine;
using UnityEngine.UI;

public class StartPauseScreen : MonoBehaviour
{
    private TimerManager timerManager;

    void Start()
    {
        timerManager = TimerManager.GetInstance();
        ShowStartPauseScreen();
    }

    private void Update()
    {
        // Check for ESC key press to show/hide the start/pause screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleStartPauseScreen();
        }
    }

    public void OnContinueButtonClick()
    {
        // Hide screen when continue is clicked
        HideStartPauseScreen();
    }

    private void ShowStartPauseScreen()
    {
        // Make sure reset isnt open
        GameObject resetMenu = GlobalManager.Instance.resetMenu;
        if (!resetMenu.activeSelf) {
            GameObject startPauseUI = GlobalManager.Instance.startPauseMenu;
            startPauseUI.SetActive(true);
            GlobalManager.Instance.canMoveEnvironment = false;
            Time.timeScale = 0f; // Pause the game
        }
    }

    private void HideStartPauseScreen()
    {
        GameObject startPauseUI = GlobalManager.Instance.startPauseMenu;
        startPauseUI.SetActive(false);
        Debug.Log("Setting False");
        GlobalManager.Instance.canMoveEnvironment = true;
        Time.timeScale = 1f; // Resume the game
    }

    private void ToggleStartPauseScreen()
    {
        GameObject startPauseUI = GlobalManager.Instance.startPauseMenu;
        Debug.Log("TOGGLE");
        if (startPauseUI.activeSelf)
        {
            HideStartPauseScreen();
        }
        else
        {
            ShowStartPauseScreen();
        }
    }
}
