using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDisconnectedController : MonoBehaviour
{
    [SerializeField] DisconnectedGamepad m_disconnectedGamePad;
    public void DisableGameObejct()
    {
        m_disconnectedGamePad.m_disconnectedPopup.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
