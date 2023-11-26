using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class DisconnectedGamepad : MonoBehaviour
{
    public PostProcessVolume m_postProcessVolume;
    public Animator m_animator;
    public GameObject m_disconnectedPopup;
    [SerializeField] private PopupDisconnectedController m_popupDisconnectedController;

    void Update()
    {
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Disconnected:
                    m_disconnectedPopup.SetActive(true);
                    m_postProcessVolume.enabled = true;
                    m_animator.SetBool("Disconnected", true);
                    Time.timeScale = 0f;
                    break;
                case InputDeviceChange.Reconnected:
                    m_animator.SetBool("Reconnected", true);
                    m_postProcessVolume.enabled = false;
                    break;
            }
}       ;
    }
}