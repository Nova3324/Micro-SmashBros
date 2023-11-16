using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerDrawStats : MonoBehaviour
{
    [Header("Damage Text Color")]
    [SerializeField] private Color32 m_color0;
    [SerializeField] private Color32 m_color50;
    [SerializeField] private Color32 m_color100;
    [SerializeField] private Color32 m_color150;
    [SerializeField] private Color32 m_color200;

    //UI Components
    private TMP_Text m_textName;
    private TMP_Text m_textDmg;
    private DrawHearts m_drawHearts;

    /*----------------------------------------------------------*/

    public void SetUiElements(GameObject UIperso, ScriptableReader playerStats)
    {
        if (UIperso != null)
        {
            //texts dmg & name
            TMP_Text[] texts = UIperso.GetComponentsInChildren<TMP_Text>();
            if (texts.Count() >= 2)
            {
                m_textDmg = texts[0];
                m_textName = texts[1];
                m_textName.text = playerStats.m_name;
            }

            //hearts
            m_drawHearts = UIperso.GetComponentInChildren<DrawHearts>();
        }
    }

    public void ChangeLife(int life)
    {
        if (m_drawHearts != null)
        {
            m_drawHearts.ChangeHeartsState(life);
        }
    }

    public void ChangeDmg(int damageTaken)
    {
        if (m_textDmg != null)
        {
            m_textDmg.text = damageTaken.ToString() + " %";
            ColorDmgText(damageTaken);
        }
    }

    /*----------------------------------------------------------*/

    private void ColorDmgText(int damageTaken)
    {
        float lerpIndex = (damageTaken % 50f) / 50f;
        Debug.Log(lerpIndex + " dmg : " + damageTaken);
        Color textColor;

        if (damageTaken < 50)
        {
            textColor = Color32.Lerp(m_color0, m_color50, lerpIndex);
        }
        else if (damageTaken < 100)
        {
            textColor = Color32.Lerp(m_color50, m_color100, lerpIndex);
            Debug.Log("yes : " + textColor + " : " + lerpIndex);
        }
        else if (damageTaken < 150)
        {
            textColor = Color32.Lerp(m_color100, m_color150, lerpIndex);
        }
        else if (damageTaken < 200)
        {
            textColor = Color32.Lerp(m_color150, m_color200, lerpIndex);
        }
        else
        {
            textColor = m_color200;
        }

        m_textDmg.color = textColor;
    }
}
