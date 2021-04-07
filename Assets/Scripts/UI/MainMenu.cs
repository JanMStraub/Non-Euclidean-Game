using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _fly = false;

    void Start () {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void PlayGameDonut () {
        SceneManager.LoadScene("Donut");
        Time.timeScale = 1f; // Game speed is set to normal
    }

    public void PlayGameKleinBottle () {
        SceneManager.LoadScene("KleinBottle");
        Time.timeScale = 1f; // Game speed is set to normal
    }

    public void QuitGame () {
        Application.Quit();
    }

    public void output () {
        if (_fly) {
            Debug.Log("fly");
        }

        if (!_fly) {
            Debug.Log("no fly");
        }
    }

}
