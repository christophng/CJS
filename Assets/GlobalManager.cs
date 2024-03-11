using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager instance;

    public GameObject resetMenu;

    public GameObject startPauseMenu;

    public GameObject goalUI;

    public bool canMoveEnvironment = true;

    public static GlobalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GlobalManager");
                    instance = obj.AddComponent<GlobalManager>();
                }
            }
            return instance;
        }
    }

    // Ensure the instance is not destroyed when reloading scenes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(resetMenu);
            DontDestroyOnLoad(startPauseMenu);
            DontDestroyOnLoad(goalUI);
            // DontDestroyOnLoad(canMoveEnvironment);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
