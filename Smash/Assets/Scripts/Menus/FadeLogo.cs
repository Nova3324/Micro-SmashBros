using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLogo : MonoBehaviour
{
    [SerializeField] GameObject m_LogoLaHorde;
    CanvasGroup m_Logo;
    private bool m_fadeIn;
    private bool m_fadeOut;
    private float m_timer;
    
    void Start()
    {
        m_fadeIn = true;
        m_fadeOut = false;

        m_Logo = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if(m_LogoLaHorde.activeSelf == true)
        {
            if (m_timer >= 0.5)
            {
                if (m_fadeIn)
                    ShowLogo();
                else if (m_fadeOut)
                    HideLogo();
            }
            
            TimeBeforeFade();
        }
    }

    private void TimeBeforeFade()
    {
        m_timer += Time.deltaTime;
    }

    private void ShowLogo()
    {
        m_Logo.alpha += 1f * Time.deltaTime;

        if (m_Logo.alpha >= 1 && m_timer >= 2f)
        {
            m_fadeIn = false;
            m_fadeOut = true;
        }
    }

    private void HideLogo()
    {
        m_Logo.alpha -= 1f * Time.deltaTime;
        if (m_Logo.alpha <= 0)
        {
            m_LogoLaHorde.SetActive(false);
            SceneManager.LoadScene("Menu Principal");
        }
    }
}
