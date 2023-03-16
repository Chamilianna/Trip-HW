using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int numLives = 3;

    public Slider healthSlider;

    public GameObject screenFade;

    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            numLives--;
            if (numLives > 0)
            {
                StartCoroutine("Respawn");
            }
            else
            {
                StartCoroutine("GameOver");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
    }

    IEnumerator Respawn()
    {
        isDead = true;
        screenFade.SetActive(true);
        yield return new WaitForSeconds(3);
        isDead = false;
        currentHealth = maxHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GameOver()
    {
        isDead = true;
        screenFade.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}
