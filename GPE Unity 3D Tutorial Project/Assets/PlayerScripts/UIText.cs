using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    public Text killText;
    SpawnScript spawner;

    void UITextChanger()
    {
        killText.text = ("Killstreak: " + spawner.killStreak);
        Debug.log
    }

}
