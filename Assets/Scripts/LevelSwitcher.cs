using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public string nextLevelName = "Level2";
    public float delayTime = 1.0f;
    public GameObject Goal;

    private bool canSwitchLevels = false;

    void Start()
    {
        // Set initial parameters
        canSwitchLevels = false;
    }

    void Update()
    {
        // Check for conditions to switch levels
        if (canSwitchLevels && Input.GetKeyDown(KeyCode.Space))
        {
            // Load the next level after a delay
            Invoke("LoadNextLevel", delayTime);
        }
    }

    void OnTriggerEnter(Collider Goal)
    {
        // Check for collision with trigger object
        if (Goal.CompareTag("Player"))
        {
            canSwitchLevels = true;
        }
    }

    void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene("Level2");
    }
}
