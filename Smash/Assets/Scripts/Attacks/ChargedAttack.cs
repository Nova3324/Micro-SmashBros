using System.Collections;
using UnityEngine;

public class ChargedAttack: MonoBehaviour
{
    [Header("atk params")]
    [SerializeField] private GameObject m_pbProjectile;
    [SerializeField] private float m_maxChargeTime;
    [SerializeField] private float m_refreshTime;

    [Header("hit box move")]
    [SerializeField] private Transform m_trsAtkOrigin;

    private bool m_isCharging;
    private bool m_isCanCharge = true;
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
        if (!m_isCharging && m_isCanCharge) 
        {
            m_isCharging = true;
            m_currentChargeTime = 0;

            PlayerController playerController = GetComponent<PlayerController>();
            playerController.m_playerMovement.SetPlayerIsStatic(true);
        }
    }

    public void LaunchAtk()
    {
        if (m_isCharging)
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.m_playerMovement.SetPlayerIsStatic(false);

            m_isCharging = false;
            StartCoroutine(CantCharge());

            //Throw projectile
            GameObject goProjectile = Instantiate(m_pbProjectile, m_trsAtkOrigin.position, Quaternion.identity);
            if (goProjectile.TryGetComponent(out Projectile projectile))
            {
                //Atk where player look
                if (m_atkDirection == Vector2.zero)
                {
                    //TODO where player look
                    m_atkDirection = Vector2.left;
                }

                projectile.Throw(m_atkDirection, (m_currentChargeTime / m_maxChargeTime), playerController);
            }
        }
    }

    /*----------------------------------------------------------*/

    private IEnumerator CantCharge()
    {
        m_isCanCharge = false;
        float timeSinceAtk = 0f;

        while(timeSinceAtk < m_refreshTime)
        {
            timeSinceAtk += Time.deltaTime;
            yield return null;
        }

        if (timeSinceAtk >= m_refreshTime)
            m_isCanCharge = true;
    }
}
