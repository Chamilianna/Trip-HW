using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLevel1 : MonoBehaviour
{
    private void SetLevelObjectActive(bool isActive)
    {
        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Find the game object you want to set by its name
        GameObject levelObject = GameObject.Find("LevelObject");

        // Alternatively, find the game object by its tag
        // GameObject levelObject = GameObject.FindGameObjectWithTag("LevelObject");

        // If the game object was found, set its active state
        if (levelObject != null)
        {
            levelObject.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("Level object not found in scene " + currentScene.name);
        }
    }
}
