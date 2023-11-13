using System.Collections.Generic;
using UnityEngine;

public class HitBoxDealDamage : MonoBehaviour
{
    private List<PlayerController> m_PlayersHitted;
    private Transform m_playerAttacker;

    [HideInInspector] public int m_atkDamage;
    [HideInInspector] public bool m_isPassThroughPlayer = true;

    private void OnEnable()
    {
        m_PlayersHitted = new List<PlayerController>();

        //put itself
        PlayerController playerC = GetComponentInParent<PlayerController>();
        m_PlayersHitted.Add(playerC);
        m_playerAttacker = playerC.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            //collid with player
            if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {
                //touch one time an player
                PlayerController playerC = collision.GetComponentInParent<PlayerController>();
                if (playerC != null && !m_PlayersHitted.Contains(playerC))
                {
                    Debug.Log(playerC.transform.parent.gameObject.name);
                    m_PlayersHitted.Add(playerC);

                    //Dmg
                    playerC.m_playerLife.TakeDamage(m_atkDamage, m_playerAttacker);

                    //Continue or not if collid player
                    if (!m_isPassThroughPlayer)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
