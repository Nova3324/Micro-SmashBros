using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PopupDisconnectedController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private DisconnectedGamepad m_disconnectedGamePad;

    [Header("Button")]
    [SerializeField] private GameObject m_continue;
    
    [Header("Player Manager")]
    [SerializeField] private GameObject m_playerManager;

    private void Update()
    {
        Selectable continueSelectable = m_continue.GetComponent<Selectable>();

        if (continueSelectable != null)
            continueSelectable.Select();
    }

    public void DisableGameObejct()
    {
        m_disconnectedGamePad.m_disconnectedPopup.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Continue()
    {
        m_disconnectedGamePad.m_animator.SetBool("Reconnected", true);
        m_disconnectedGamePad.m_postProcessVolume.enabled = false;
    }
}
