using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHealthText : MonoBehaviour
{
    public Text healthText = null;

    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        healthText.text = "Health: " + healthSystem.GetHealth();

        Debug.Log("Health: " + healthSystem.GetHealth());
    }
}