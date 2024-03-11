using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;

    private float timer;

    public float Timer => timer;

    public void ResetTimer()
    {
        timer = 0f;
    }

    private void UpdateTimer()
    {
        if (Time.timeScale != 0) // Make sure not frozen
        {
            timer += Time.deltaTime;
        }
    }

    // make sure only one timer exists
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        UpdateTimer();
    }

    public static TimerManager GetInstance()
    {
        return instance;
    }

    public float GetTimerValue()
    {
        return timer;
    }
}
