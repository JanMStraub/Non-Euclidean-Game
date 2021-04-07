using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
    private KeyHandler _KH;
    public AudioClip keySound;

    void Start () {
        _KH = GameObject.Find("Canvas").GetComponent<KeyHandler>();
    }

    private void OnTriggerEnter (Collider other) {
        _KH.keys++;
        // creates temporary audio source
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(gameObject);
    }    
}
