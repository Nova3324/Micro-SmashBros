using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Map2 - Pleasure Graveyard");
        AudioManager.Instance.PressedButton();
        Time.timeScale = 1.0f;
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        AudioManager.Instance.PressedButton();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        AudioManager.Instance.PressedButton();
    }

    public void Quit()
    {
        Application.Quit();
        AudioManager.Instance.PressedButton();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu Principal");
        AudioManager.Instance.PressedButton();
    }
}
