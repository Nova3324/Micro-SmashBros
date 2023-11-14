using System.Collections.Generic;
using UnityEngine;

public class HitBoxDealDamage : MonoBehaviour
{
    private List<PlayerController> m_PlayersHitted = new();
    private Transform m_playerAttacker;

    [HideInInspector] public int m_atkDamage;
    [HideInInspector] public bool m_isPassThroughPlayer = true;

    [SerializeField] private Transform m_parentTrs;

    /*----------------------------------------------------------*/

    private void Awake()
    {
        m_parentTrs = m_parentTrs != null ? m_parentTrs : transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null && m_playerAttacker == null)
        {
            return;
        }

        //Collid with solid
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Solid")) &&
            m_parentTrs != transform)
        {
            //TODO anim destroy
            Destroy(m_parentTrs.gameObject);
        }

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
                    m_parentTrs.gameObject.SetActive(false);
                }
            }
        }
    }

    /*----------------------------------------------------------*/

    public void SetAttacker(PlayerController playerController)
    {
        m_PlayersHitted.Clear();

        //put itself
        m_PlayersHitted.Add(playerController);
        m_playerAttacker = playerController.transform;
    }
}
