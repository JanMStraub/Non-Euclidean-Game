using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour {

    public Transform start;
    public Transform destination;
    private Transform player;
    private bool playerIsOverlapping = false;
    private bool timeIsUp = false;
    private float cooldown = 5.0f;

    void Start () {
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate() {
        if (playerIsOverlapping) {

			// If this is true: The player has moved across the portal
			if (timeIsUp)
			{   
                timeIsUp = false;
                cooldown = 5f;
				player.position = destination.position;
				playerIsOverlapping = false;
                Debug.Log("teleported");
			}
        }
        if (cooldown >= -1.0f){
            Timer();
        }
    }

    void OnTriggerEnter() {
        playerIsOverlapping = true;
    }

    void OnTriggerExit() {
        playerIsOverlapping = false;
        timeIsUp = false;
    }

    void Timer() {

        if (cooldown <= 0.0f) {
            timeIsUp = true;
        }
        Debug.Log(cooldown);
        cooldown -= Time.deltaTime;

    }
}