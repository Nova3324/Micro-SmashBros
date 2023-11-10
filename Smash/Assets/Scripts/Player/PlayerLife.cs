using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int m_life = 3;
    private int m_damageTaken = 0;

    //knockback
    private float m_knockbackCoef = 0.01f;

    /*----------------------------------------------------------*/

    public void TakeDamage(int damage)
    {
        m_damageTaken += damage;
        m_damageTaken = Mathf.Clamp(m_damageTaken, 0, 999);
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

    private void Knockback(int damage)
    {
        float knockback = Mathf.Pow(m_damageTaken, 2f) * m_knockbackCoef * damage;

        //TODO knockback /= playerMass
    }
}
