using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PopupDisconnectedController : MonoBehaviour
{
    [SerializeField] DisconnectedGamepad m_disconnectedGamePad;
    [SerializeField] private GameObject m_continue;
    public void DisableGameObejct()
    {
        m_disconnectedGamePad.m_disconnectedPopup.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Update()
    {

        Selectable continueSelectable = m_continue.GetComponent<Selectable>();

        if (continueSelectable != null)
            continueSelectable.Select();
    }

    public void Continue()
    {
        m_disconnectedGamePad.m_animator.SetBool("Reconnected", true);
        m_disconnectedGamePad.m_postProcessVolume.enabled = false;
    }
}
