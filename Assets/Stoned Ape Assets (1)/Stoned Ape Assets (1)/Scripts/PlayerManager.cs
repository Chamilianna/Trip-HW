using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int health = 100;
    public int lostHealth = 5;
    public Animator player;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        InvokeRepeating("ReduceHealth", 1, 1);
    }

    void ReduceHealth()
    {
        health -= lostHealth;
        healthBar.value = health;
        if(health <= 0)
        {
            player.Play("DAMAGED01");
            StartCoroutine(SceneChange());

        }
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level 1");
    }

}
