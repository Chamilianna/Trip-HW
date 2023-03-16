using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public int numLevels = 2;
    public GameObject shockWave;
    public Slider healthBar;
    public GameObject playerPrefab;

    private Vector3 startPos;
    private Quaternion startRot;

    private int levelNumber = 1;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            RespawnPlayer();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            SetStartPosition(other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Instantiate(shockWave, other.transform.position, other.transform.rotation);
        }
        else if (other.CompareTag("Goal"))
        {
            GetComponent<Animator>().Play("WIN00");
            Destroy(other.gameObject, 3.5f);
            levelNumber++;
            if (levelNumber <= numLevels)
            {
                if (levelNumber == 1)
                {
                    SpawnPlayerInLevel2();
                    Destroy(gameObject);
                }
                else if (levelNumber == 2)
                {
                    LoadNextLevel();
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void RespawnPlayer()
    {
        if (CollectHealth.lives > 0)
        {
            CollectHealth.lives--;
            CollectHealth.health = 0;
            healthBar.value = CollectHealth.health;
            StartCoroutine(PlayLoseAnimation());

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = startPos;
                transform.rotation = startRot;
                GetComponent<CharacterController>().enabled = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level1");
            }
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }

    private void SetStartPosition(Vector3 position, Quaternion rotation)
    {
        startPos = position;
        startRot = rotation;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    private void SpawnPlayerInLevel2()
    {
        Instantiate(playerPrefab, new Vector3(5, 5, 5), Quaternion.identity)
            .GetComponent<Respawn>().enabled = true;
    }

    private IEnumerator PlayLoseAnimation()
    {
        GetComponent<Animator>().Play("LOSE00");
        yield return new WaitForSeconds(3);
        CollectHealth.health = 100;
        healthBar.value = CollectHealth.health;
    }
}
