using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _GameIsPaused = false;
    public GameObject PauseMenuUi;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.Confined;
            Debug.Log("Ecs");
            if (_GameIsPaused) {
                Resume ();
            } else {
                Pause ();
                Debug.Log("pause");
            }
        }
    }

    public void Resume () {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f; // Game speed is set to normal
        _GameIsPaused = false;
    }

    public void LoadMenu () {
        Time.timeScale = 1f; // Game speed is set to normal
        SceneManager.LoadScene("Menu");
    }

    void Pause () {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f; // Game is paused
        _GameIsPaused = true;
    }

}
