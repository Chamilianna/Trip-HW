using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectHealth : MonoBehaviour
{
    public Slider healthBar;

    public GameObject screenFade;

    public static int health = 100;

    public static int lives = 3;

    public GameObject[] monkeyBust = new GameObject[3];

    public AudioSource collectSound;

    public AudioClip[] collectClips;

    private readonly HashSet<GameObject> alreadyCollidedWith = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 2)
        {
            monkeyBust[2].SetActive(false);
        }
        if(lives == 1)
        {
            monkeyBust[1].SetActive(false);
        }
        if(lives <= 0)
        {
            monkeyBust[0].SetActive(false);
            StartCoroutine(RestartGame());
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "PlainShroom" && !alreadyCollidedWith.Contains(hit.gameObject))
        {
            alreadyCollidedWith.Add(hit.gameObject);
            collectSound.clip = collectClips[Random.Range(0, collectClips.Length)];
            collectSound.Play();
            Destroy(hit.gameObject);
            health += 5;
            health = Mathf.Clamp(health, 0, 100);
            print(health);
            healthBar.value = health;
        }
        if(hit.gameObject.tag == "PinkShroom" && !alreadyCollidedWith.Contains(hit.gameObject))
        {
            alreadyCollidedWith.Add(hit.gameObject);
            collectSound.clip = collectClips[Random.Range(0, collectClips.Length)];
            collectSound.Play();
            Destroy(hit.gameObject);
            health += 10;
            health = Mathf.Clamp(health, 0, 100);
            print(health);
            healthBar.value = health;
        }
        if(hit.gameObject.tag == "PurpleShroom" && !alreadyCollidedWith.Contains(hit.gameObject))
        {
            alreadyCollidedWith.Add(hit.gameObject);
            collectSound.clip = collectClips[Random.Range(0, collectClips.Length)];
            collectSound.Play();
            Destroy(hit.gameObject);
            health += 20;
            health = Mathf.Clamp(health, 0, 100);
            print(health);
            healthBar.value = health;
        }
        if(hit.gameObject.tag == "GreenShroom" && !alreadyCollidedWith.Contains(hit.gameObject))
        {
            alreadyCollidedWith.Add(hit.gameObject);
            collectSound.clip = collectClips[Random.Range(0, collectClips.Length)];
            collectSound.Play();
            Destroy(hit.gameObject);
            health -= 100;
            health = Mathf.Clamp(health, 0, 100);
            print(health);
            healthBar.value = health;
            lives--;
        }
    }


    void DetractHealth()
    {
        health -= 20;
        health = Mathf.Clamp(health, 0, 100);
        healthBar.value = health;
    }

    IEnumerator RestartGame()
    {
        screenFade.SetActive(true);
        yield return new WaitForSeconds(3);
        lives = 3;
        SceneManager.LoadScene(1);
    }
}