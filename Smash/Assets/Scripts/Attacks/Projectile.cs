using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectiles Params")]
    [SerializeField] private float m_speed;
    [SerializeField] private bool m_isChargementIncreaseDmg = true;
    [SerializeField] private bool m_isPassThroughPlayers;
    [SerializeField][Range(0, 100)] private int m_maxDamage; //charged max time

    [SerializeField] private Transform m_trsHitBox;

    [Header("Initial Scale")]
    [SerializeField] private float m_timeToMaxScale;
    private float m_currentScaleTime;

    [Header("Charged Atk Params")]
    private Vector3 m_direction;
    [Range(0f, 1f)] private float m_chargeRatio;

    private void FixedUpdate()
    {
        
    }

    /*----------------------------------------------------------*/

    public void Throw(Vector3 direction, float chargeRatio)
    {
        m_direction = direction;
        m_chargeRatio = chargeRatio;

        m_trsHitBox.gameObject.SetActive(true);
        if (m_trsHitBox.TryGetComponent(out HitBoxDealDamage hitBoxScript))
        {
            if (m_isChargementIncreaseDmg)
            {
                hitBoxScript.m_atkDamage = Mathf.RoundToInt(m_maxDamage * m_chargeRatio);
                hitBoxScript.m_isPassThroughPlayer = m_isPassThroughPlayers;
            }
            else
            {
                hitBoxScript.m_atkDamage = m_maxDamage;
                hitBoxScript.m_isPassThroughPlayer = m_isPassThroughPlayers;
            }
        }
    }

    /*----------------------------------------------------------*/

    private IEnumerator Scale0To1()
    {
        m_currentScaleTime = 0;

        while (m_currentScaleTime < m_timeToMaxScale)
        {
            //scale hitbox
            m_currentScaleTime += Time.deltaTime;
            m_currentScaleTime = Mathf.Clamp(m_currentScaleTime, 0, m_timeToMaxScale);
            transform.localScale = Vector3.one * (m_timeToMaxScale / m_currentScaleTime);

            yield return null;
        }
    }

}
