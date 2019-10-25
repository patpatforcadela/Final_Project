using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayState");
    }
	public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
