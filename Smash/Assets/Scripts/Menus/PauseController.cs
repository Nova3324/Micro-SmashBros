using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject m_settings, m_pause, m_back, m_continue;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_settings.SetActive(false);
        m_pause.SetActive(false);
    }

    public void Settings()
    {
        m_settings.SetActive(true);
        m_pause.SetActive(false);

        Selectable backSelectable = m_back.GetComponent<Selectable>();

        if (backSelectable != null)
            backSelectable.Select();
    }

    public void Continue()
    {
        m_pause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Principal");
        Time.timeScale = 1.0f;
    }

    public void BackSettings()
    {
        m_pause.SetActive(true);
        m_settings.SetActive(false);

        Selectable continueSelectable = m_continue.GetComponent<Selectable>();

        if (continueSelectable != null)
            continueSelectable.Select();
    }

    public void Back()
    {
        if (m_pause.activeSelf)
        {
            m_pause.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else if(m_settings.activeSelf)
        {
            m_settings.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0f;
            m_pause.SetActive(true);
            m_settings.SetActive(false);

            Selectable continueSelectable = m_continue.GetComponent<Selectable>();

            if (continueSelectable != null)
                continueSelectable.Select();
        }
    }
}
