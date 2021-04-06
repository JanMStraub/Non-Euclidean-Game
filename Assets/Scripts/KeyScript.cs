using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public KeyHandler KH;
    public AudioClip keySound;

    void Start() {
        KH = GameObject.Find("Canvas").GetComponent<KeyHandler>();
    }

    private void OnTriggerEnter(Collider other) {
        KH.keys++;
        // creates temporary audio source
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(gameObject);
    }    
}
