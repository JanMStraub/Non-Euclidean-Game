using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public GameObject GameOverScreen;

    public bool PlayerIsAlive = true;


    void Update () { // True if enemy killed the player

        if (!PlayerIsAlive) {
            Cursor.lockState = CursorLockMode.Confined;
            Pause();
        }
    }


    public void LoadMenu () {

        Time.timeScale = 1f; // Game speed is set to normal
        SceneManager.LoadScene("Menu");
    }


    void Pause () {

        GameOverScreen.SetActive(true);
        Time.timeScale = 0f; // Game is paused
    }
}
