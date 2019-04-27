using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;            
    public int currentHealth;
    public Animator anim;
    public Slider healthBar;
    public GameObject medkitPrefab;

    bool isDead;
    bool damaged;

    private void Start()
    {
        healthBar.maxValue = startingHealth;
    }

    void Awake()
    {
        anim.GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("IsDead") == true && isDead == false)
        {
            Death();
        }
    }

    public void TakeDamage(int damageAmount)
    {
    damaged = true;

        currentHealth -= damageAmount;
        healthBar.value = currentHealth;

        if (healthBar)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {

        isDead = true;
        GameObject medkit = Instantiate(medkitPrefab);
        anim.SetBool("IsDead", true);
        Destroy(gameObject, 2f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(50);
            Debug.Log("got hit");
        }
    }

}
