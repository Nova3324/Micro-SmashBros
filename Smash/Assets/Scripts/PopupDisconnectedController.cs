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

    [Header("Player Infos")]
    [SerializeField] private List<Image> m_playersSpriteInPopup = new List<Image>();
    [SerializeField] private List<GameObject> m_players = new List<GameObject>();
    
    private List<SpriteRenderer> m_playersSprite = new List<SpriteRenderer>();
    public void DisableGameObejct()
    {
        m_disconnectedGamePad.m_disconnectedPopup.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Start()
    {

        foreach (GameObject parent in m_players)
        {
            Transform parentTransform = parent.transform;

            Transform sprite = parentTransform.Find("Sprites/Head");

            if (sprite != null)
            {
                m_playersSprite.Add(sprite.gameObject.GetComponent<SpriteRenderer>());
            }
        }

        for (int i = 0; i < m_playersSprite.Count; i++)
        {
            m_playersSpriteInPopup[i].sprite = m_playersSprite[i].sprite;
        }
    }
    private void Update()
    {
        SwapColor();

        Selectable continueSelectable = m_continue.GetComponent<Selectable>();

        if (continueSelectable != null)
            continueSelectable.Select();
    }

    public void Continue()
    {
        m_disconnectedGamePad.m_animator.SetBool("Reconnected", true);
        m_disconnectedGamePad.m_postProcessVolume.enabled = false;
    }

    private void SwapColor()
    {
        for (int i = 0; i < m_players.Count; i++)
        {
            if (m_players[i].gameObject.activeSelf == true)
            {
                m_playersSpriteInPopup[i].color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
