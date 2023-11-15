using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class BasicAttack : MonoBehaviour
{
    [Header("atk params")]
    [SerializeField] private int m_damage = 2;
    [SerializeField] private float m_range = 2.5f;
    [SerializeField] private float m_atkDuration = 0.1f;

    [Header("hit box move")]
    [SerializeField] private Transform m_trsPunchOrigin;
    [SerializeField] private Transform m_trsPunchHitBox;

    private float m_currentDuration;
    private Vector2 m_atkDirection = new();

    /*----------------------------------------------------------*/

    private void Start()
    {
        StopPunch();
    }

    /*----------------------------------------------------------*/

    public void SetAttackDirection(Vector2 direction)
    {
        if (direction.magnitude <= 1 && direction.magnitude > 0)
        {
            m_atkDirection = direction;
        }
    }

    public void LaunchAttack()
    {
        Assert.IsNotNull(m_trsPunchHitBox); 
        Assert.IsNotNull(m_trsPunchOrigin);

        //Atk where player look
        if (m_atkDirection == Vector2.zero)
        {
            //TODO where player look
            m_atkDirection = Vector2.left;
        }

        StartCoroutine(MovePunchHitbox(m_atkDirection));
    }

    /*----------------------------------------------------------*/

    private void StopPunch()
    {
        StopAllCoroutines();
        m_trsPunchHitBox.position = m_trsPunchOrigin.position;
        m_trsPunchHitBox.gameObject.SetActive(false);
    }
    private IEnumerator MovePunchHitbox(Vector3 dir)
    {
        m_trsPunchHitBox.gameObject.SetActive(true);
        m_currentDuration = 0;
        if (m_trsPunchHitBox.TryGetComponent(out HitBoxDealDamage hitBoxScript))
        {
            hitBoxScript.SetAttacker(GetComponent<PlayerController>(), dir);
            hitBoxScript.m_atkDamage = m_damage;
        }

        while (m_currentDuration < 1)
        {
            //move hitbox
            m_currentDuration += Time.deltaTime;
            float m_lerpIndex = m_currentDuration / m_atkDuration;
            m_lerpIndex = Mathf.Clamp01(m_lerpIndex);

            m_trsPunchHitBox.position = Vector3.Lerp(m_trsPunchOrigin.position, m_trsPunchOrigin.position + dir * m_range, m_lerpIndex);

            //stop punch at end of movement
            if (m_lerpIndex == 1)
            {
                StopPunch();
            }

            yield return null;
        }
    }
}
