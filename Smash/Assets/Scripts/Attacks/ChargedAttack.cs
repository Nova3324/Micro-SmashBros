using UnityEngine;

public class ChargedAttack: MonoBehaviour
{
    [Header("atk params")]
    [SerializeField] private GameObject m_pbProjectile;
    [SerializeField] private float m_maxChargeTime;

    [Header("hit box move")]
    [SerializeField] private Transform m_trsAtkOrigin;

    private bool m_isCharging;
    private float m_currentChargeTime;
    private Vector2 m_atkDirection = new();

    /*----------------------------------------------------------*/

    public void UpdtChargement()
    {
        if (m_isCharging)
        {
            m_currentChargeTime += Time.deltaTime;
            //Too long chargement
            if (m_currentChargeTime >= m_maxChargeTime)
            {
                LaunchAtk();
            }
        }
    }

    public void SetAttackDirection(Vector2 direction)
    {
        if (direction.magnitude <= 1 && direction.magnitude > 0)
        {
            m_atkDirection = direction;
        }
    }

    public void StartAtkChargement()
    {
        if (!m_isCharging) 
        {
            m_isCharging = true;
            m_currentChargeTime = 0;
        }
    }

    public void LaunchAtk()
    {
        if (m_isCharging)
        {
            m_isCharging = false;

            //Throw projectile
            GameObject goProjectile = Instantiate(m_pbProjectile, m_trsAtkOrigin.position, Quaternion.identity);
            if (goProjectile.TryGetComponent(out Projectile projectile))
            {
                projectile.Throw(m_atkDirection, (m_currentChargeTime / m_maxChargeTime));
            }
        }
    }
}
