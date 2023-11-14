using UnityEngine;
using UnityEngine.Assertions;

public class PlayerLife
{
    //player components
    private PlayerController m_playerController;
    private ScriptableReader m_playerStats;
    private PlayerMovement m_playerMovement;
    private Transform m_playerTrs;

    private AirArea m_camAirArea;

    //life
    private int m_life = 3;

    //damage
    public bool m_isInvicible;
    private int m_damageTaken = 0;

    //knockback
    private float m_knockbackCoef = 0.01f;

    /*----------------------------------------------------------*/

    public PlayerLife(PlayerController playerController, Transform playerTransform)
    { 
        m_playerController = playerController;
        m_playerStats = playerController.m_playerStats;
        m_playerMovement = playerController.m_playerMovement;
        m_playerTrs = playerTransform;

        m_camAirArea = Camera.main.GetComponent<AirArea>();
        Assert.IsNotNull(m_camAirArea);
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

        Debug.Log(m_playerController.transform.parent.gameObject.name + " Take Damage -> Life : " + m_life + " | Damage Taken : " + m_damageTaken);

        Knockback(damage, attakerTrs);
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

        Debug.Log(m_playerController.transform.parent.gameObject.name + " Is Kicked Out -> Life : " + m_life + " | Damage Taken : " + m_damageTaken);
        
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

    private void Knockback(int damage, Transform attakerTrs)
    {
        //calcul knockback intensity
        float knockback = Mathf.Pow(m_damageTaken, 2f) * m_knockbackCoef * damage;
        knockback /= m_playerStats.m_mass;

        Vector3 dir = attakerTrs.position - m_playerTrs.position;
        dir += Vector3.up;
        dir.Normalize();

        Vector3 kbForce = dir * knockback;

        //TODO add to player movement
    }

    private void Respawn()
    {
        m_playerTrs.position = m_playerController.m_spawnPos;

        //TODO reset velocity
        //TODO become invincible for 3s
    } 
}
