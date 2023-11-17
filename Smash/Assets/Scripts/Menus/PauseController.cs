using UnityEngine;
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
        SwitchActionMap("Game");
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
        if(!m_pause.activeSelf) 
        {
            m_pause.SetActive(true);
            m_settings.SetActive(false);

            Selectable continueSelectable = m_continue.GetComponent<Selectable>();

            if (continueSelectable != null)
                continueSelectable.Select();
        }
    }

    public void Back()
    {
        if (m_pause.activeSelf)
        {
            SwitchActionMap("Game");
            m_pause.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else if(m_settings.activeSelf)
        {
            SwitchActionMap("Game");
            m_settings.SetActive(false);
            m_pause.SetActive(true);
            Time.timeScale = 1.0f;

            Selectable continueSelectable = m_continue.GetComponent<Selectable>();

            if (continueSelectable != null)
                continueSelectable.Select();
        }
        else
        {
            SwitchActionMap("Menu");
            Time.timeScale = 0f;
            m_pause.SetActive(true);
            m_settings.SetActive(false);

            Selectable continueSelectable = m_continue.GetComponent<Selectable>();

            if (continueSelectable != null)
                continueSelectable.Select();
        }
    }

    public void SwitchActionMap(string actionName)
    {
        var playerInputs = FindObjectsOfType<InputsController>();

        foreach (var playerInput in playerInputs)
        {
            playerInput.m_playerInput.SwitchCurrentActionMap(actionName);
        }
    }
}
