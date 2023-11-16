using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Devroom Cedric");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");    
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
