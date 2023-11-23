using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class DisconnectedGamepad : MonoBehaviour
{
    [SerializeField] private PostProcessVolume m_postProcessVolume;
    [SerializeField] private Animator m_animator;
    public GameObject m_disconnectedPopup;

    void Update()
    {
        if (Gamepad.current == null)
        {
            m_disconnectedPopup.SetActive(true);
            m_postProcessVolume.enabled = true;
            m_animator.SetBool("Disconnected", true);
            Time.timeScale = 0f;
        }
        else 
        {
            m_animator.SetBool("Reconnected", true);
            m_postProcessVolume.enabled = false;
        }
    }
}