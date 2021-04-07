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
    }

    public void PlayGameKleinBottle () {
        SceneManager.LoadScene("KleinBottle");
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
