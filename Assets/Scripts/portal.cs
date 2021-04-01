using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour {

    public CharacterController controller;
    public Transform player;
    public Transform portalA;
    public Transform portalB;
    private bool playerIsOverlapping = false;

    void Update() {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// Teleport him!
	
				player.position = portalB.position;
                print("woosch");

				playerIsOverlapping = false;
                // controller.enable = true;
			}
        }
    }

    void OnTriggerEnter() {
        playerIsOverlapping = true;
        // controller.enable = false;
        print("teleported");
    }
}