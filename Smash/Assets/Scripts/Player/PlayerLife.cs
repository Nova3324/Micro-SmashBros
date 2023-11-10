using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private ScriptableReader m_playerStats;
    private PlayerMovement m_playerMovement;

    public bool m_isInvicible;

    private int m_life = 3;
    private int m_damageTaken = 0;

    //knockback
    private float m_knockbackCoef = 0.01f;

    /*----------------------------------------------------------*/

    public PlayerLife(ScriptableReader playerStats, PlayerMovement playerMovement)
    { 
        m_playerStats = playerStats;
        m_playerMovement = playerMovement;
    }

    /*----------------------------------------------------------*/

    public void TakeDamage(int damage, Transform attakerTrs)
    {
        if (m_isInvicible)
        {
            return;
        }

        m_damageTaken += damage;
        m_damageTaken = Mathf.Clamp(m_damageTaken, 0, 999);

        Knockback(damage, attakerTrs);
    }

    public void KickedOut()
    {
        m_life--;
        m_damageTaken = 0;


        if (m_life > 0)
        {
            //TODO Respawn
        }
        else
        {
            //TODO Game Over
        }
    }

    /*----------------------------------------------------------*/

    private void Knockback(int damage, Transform attakerTrs)
    {
        //calcul knockback intensity
        float knockback = Mathf.Pow(m_damageTaken, 2f) * m_knockbackCoef * damage;
        knockback /= m_playerStats.m_mass;

        Vector3 dir = attakerTrs.position - transform.position;
        dir += Vector3.up;
        dir.Normalize();

        Vector3 kbForce = dir * knockback;

        //TODO multiply by direction and add to player
    }
}
