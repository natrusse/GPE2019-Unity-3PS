using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float respawnTime = 3;
    public Animator anim;
    public Slider healthBar;
    public SpawnScript spawner;

    CharControlReworked charControl;

    bool isDead;
    bool damaged;

    private void Start()
    {
        healthBar.maxValue = startingHealth;
        currentHealth = startingHealth;
    }

    void awake ()
    {
        anim.GetComponent<Animator>();
        charControl = GetComponent<CharControlReworked>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateHealthbar();
        if (currentHealth >= 100) currentHealth = 100;
	}

    private void UpdateHealthbar()
    {
        if (healthBar)
        {
            healthBar.value = currentHealth;
        }
    }


    public void TakeDamage (int damageAmount)
    {
        damaged = true;

        currentHealth -= damageAmount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {

            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("IsDead");
        SceneManager.LoadScene("gameover");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(5);
        }
    }

}