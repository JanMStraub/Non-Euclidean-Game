using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public GameObject EndScreenMenu;

    public bool allKeys = false;


    // Update is called once per frame
    void Update () {

        if (allKeys) {

            Cursor.lockState = CursorLockMode.Confined;
            Pause();
        }
    }


    public void LoadMenu () {

        Time.timeScale = 1f; // Game speed is set to normal
        SceneManager.LoadScene("Menu");
    }


    void Pause () {
        
        EndScreenMenu.SetActive(true);
        Time.timeScale = 0f; // Game is paused
    }
}
