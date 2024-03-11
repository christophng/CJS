using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResetButton : MonoBehaviour
{
    private TimerManager timerManager;

    public void OnResetButtonClick()
    {

        timerManager = TimerManager.GetInstance();
        Time.timeScale = 0f; // Freeze time

        Debug.Log("BUTTON CLICKED");

        // Get ndex of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Reload current scene
        SceneManager.LoadScene(currentSceneIndex);

        GlobalManager.Instance.canMoveEnvironment = true;

        timerManager.ResetTimer(); // Reset time

        InitializeResetMenu();
    }

    public void InstantiateResetMenu()
    {
        GameObject resetMenu = GlobalManager.Instance.resetMenu;

        resetMenu.SetActive(false);
    }

    public void InitializeResetMenu()
    {
        InstantiateResetMenu();
    }
}