using UnityEngine;

public class GoalCollide : MonoBehaviour
{
    private GameObject goalScreen;

    void OnCollisionEnter(Collision collision)
    {

        goalScreen = GlobalManager.Instance.goalUI;
        Debug.Log("LOOK: " + goalScreen);

        Debug.Log("Goal Collision: " + collision.contacts[0].normal);

        Debug.Log("WON GAME");

        // Pause the game
        Time.timeScale = 0f;

        // Show the goal screen
        if (goalScreen != null)
        {
            GoalScreen goalScreenInstance = FindObjectOfType<GoalScreen>();
            if (goalScreenInstance != null)
            {
                goalScreenInstance.ShowGoalScreen();
            }
            goalScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GoalScreen reference not found!");
        }
    }
}
