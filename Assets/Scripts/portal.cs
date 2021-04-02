using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class portal : MonoBehaviour {

    public Transform player;
    public Transform start;
    public Transform destination;
    private bool playerIsOverlapping = false;
    private bool playerLeftPortal = false;

    void Update() {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = player.position - start.position;
			float dotProduct = Vector3.Dot(start.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f && playerLeftPortal)
			{
				player.position = destination.position;
                print("woosch");

				playerIsOverlapping = false;
			}
        }
    }

    void OnTriggerEnter() {
        playerIsOverlapping = true;
        print("teleported");
    }

    void OnTriggerExit() {
        playerLeftPortal = true;
        print("did it");
    }
}