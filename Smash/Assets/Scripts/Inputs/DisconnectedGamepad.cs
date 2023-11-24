using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class DisconnectedGamepad : MonoBehaviour
{
    [SerializeField] private PostProcessVolume m_postProcessVolume;
    [SerializeField] private Animator m_animator;
    public GameObject m_disconnectedPopup;

    private void Start()
    {
        
    }

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