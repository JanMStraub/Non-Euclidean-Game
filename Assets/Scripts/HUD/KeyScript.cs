using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public AudioClip keySound;

    private HUDHandler _HUDH;


    void Start () {

        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
    }


    void OnTriggerEnter (Collider other) {

        _HUDH.keys++;
        // creates temporary audio source
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(gameObject);
    }    
}
