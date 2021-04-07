using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
    private HUDHandler _HUDH;
    public AudioClip keySound;

    void Start () {
        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
    }

    private void OnTriggerEnter (Collider other) {
        _HUDH.keys++;
        // creates temporary audio source
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(gameObject);
    }    
}
