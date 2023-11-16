using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerLife
{
    //player components
    private PlayerController m_playerController;
    private ScriptableReader m_playerStats;
    private PlayerMovement m_playerMovement;
    private Transform m_playerTrs;

    //air area
    private AirArea m_camAirArea;

    //life
    private int m_life = 3;

    //damage
    public bool m_isInvicible;
    private int m_damageTaken = 0;

    //knockback
    private float m_increaseCoef = 0.06f;
    private float m_deltaCoef = 0.35f;

    /*----------------------------------------------------------*/

    public PlayerLife(PlayerController playerController, Transform playerTransform, GameObject UIperso = null)
    { 
        m_playerController = playerController;
        m_playerStats = playerController.m_playerStats;
        m_playerMovement = playerController.m_playerMovement;
        m_playerTrs = playerTransform;

        m_camAirArea = Camera.main.GetComponent<AirArea>();
        Assert.IsNotNull(m_camAirArea);

        m_playerController.m_drawStats.SetUiElements(UIperso, m_playerStats);

        m_playerController.m_drawStats.ChangeLife(m_life);
        m_playerController.m_drawStats.ChangeDmg(m_damageTaken);
    }

    /*----------------------------------------------------------*/

    public void TakeDamage(int damage, Vector3 atkDirection)
    {
        if (m_isInvicible)
        {
            return;
        }

        m_damageTaken += damage;
        m_damageTaken = Mathf.Clamp(m_damageTaken, 0, 999);

        m_playerController.m_drawStats.ChangeDmg(m_damageTaken);

        //Knockback
        Knockback(damage, atkDirection);

        //STUN
        Debug.Log("stun duration : " + (damage * 0.05f + 0.1f));
        m_playerController.Stun(damage * 0.05f + 0.1f);
    }

    public bool IsKickedOut()
    {
        //if the player is not in the Air Zone
        if (!m_camAirArea.IsInAirZone(m_playerTrs.position))
        {
            KickedOut();
            return true;
        }

        return false;
    }

    /*----------------------------------------------------------*/

    private void KickedOut()
    {
        m_life--;
        m_damageTaken = 0;

        m_playerController.m_drawStats.ChangeLife(m_life);
        m_playerController.m_drawStats.ChangeDmg(m_damageTaken);

        Respawn();

        //if (m_life > 0)
        //{
        //    Respawn();
        //}
        //else
        //{
        //    //TODO Game Over
        //}
    }

    private void Knockback(int damage, Vector3 atkDirection)
    {
        //calcul knockback intensity
        float knockback = Mathf.Pow(m_damageTaken, 2f) * m_increaseCoef;
        knockback /= m_playerStats.m_mass;
        knockback += damage;

        if (atkDirection.y >= 0)
        {
            atkDirection += Vector3.up;
        }
        atkDirection.Normalize();

        Vector3 kbForce = atkDirection * knockback * m_deltaCoef;
        m_playerMovement.AddKnockBack(kbForce);
    }

    private void Respawn()
    {
        m_playerTrs.position = m_playerController.m_spawnPos;

        m_playerMovement.ResetVelocity();
        m_playerController.BecomeInvicible();
    }
}
