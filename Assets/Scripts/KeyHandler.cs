using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyHandler : MonoBehaviour
{
    public TMP_Text KeyText;
    public int keys = 0;

    void Update () {
        KeyText.text = "Keys : " + keys;
    }
}
