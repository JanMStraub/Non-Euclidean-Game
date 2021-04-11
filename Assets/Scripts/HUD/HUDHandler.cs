using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDHandler : MonoBehaviour {

    public TMP_Text KeyText;

    public TMP_Text HealthText;

    public TMP_Text AmmoText;

    public int keys = 0;

    public float health = 0;

    public int ammo = 0;

    private EndScreen _ES;


    void Start () {

        _ES = GameObject.Find("Canvas").GetComponent<EndScreen>();
    }

    // Updates the values on screen
    void Update () {

        KeyText.text = "Keys : " + keys;
        HealthText.text = "Health : " + health;
        AmmoText.text = "Mana : " + ammo;

        if (keys == 5) {
            _ES.allKeys = true;
        }
    }
}
