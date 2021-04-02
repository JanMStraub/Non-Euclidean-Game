using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class portal : MonoBehaviour {

    public Transform start;
    public Transform destination;
    private Transform player;
    private bool playerIsOverlapping = false;

    void Start () {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        if (playerIsOverlapping) {

			// If this is true: The player has moved across the portal
			if (true)
			{
				player.position = destination.position;
				playerIsOverlapping = false;
                Debug.Log("teleported");
			}
        }
    }

    void OnTriggerEnter() {
        playerIsOverlapping = true;
    }

    void OnTriggerExit() {
        playerIsOverlapping = false;
    }
}