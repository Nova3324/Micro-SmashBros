using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Projectile : MonoBehaviour
{
    [Header("Projectiles Params")]
    [SerializeField] private float m_speed;
    [SerializeField] private bool m_isChargementIncreaseDmg = true;
    [SerializeField] private bool m_isPassThroughPlayers;
    [SerializeField][Range(0, 100)] private int m_maxDamage; //charged max time

    [SerializeField] private Transform m_trsHitBox;
    private Rigidbody2D m_rb;

    [Header("Initial Scale")]
    [SerializeField] private float m_timeToMaxScale;
    private float m_currentScaleTime;

    [Header("Charged Atk Params")]
    private Vector3 m_direction;
    private float m_chargeRatio; // between 0 and 1

    private AirArea m_airArea;

    /*----------------------------------------------------------*/

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(m_rb);
    }

    private void Start()
    {
        m_airArea = Camera.main.GetComponent<AirArea>();

        Assert.IsNotNull(m_airArea);
    }

    private void Update()
    {
        if (!m_airArea.IsInAirZone(m_trsHitBox.position))
        {
            Destroy(gameObject);
        }
    }

    /*----------------------------------------------------------*/

    public void Throw(Vector2 direction, float chargeRatio, PlayerController playerController)
    {
        m_direction = direction;
        m_chargeRatio = chargeRatio;
        Move();

        m_trsHitBox.gameObject.SetActive(true);
        if (m_trsHitBox.TryGetComponent(out HitBoxDealDamage hitBoxScript))
        {
            if (m_isChargementIncreaseDmg)
            {
                hitBoxScript.SetAttacker(playerController, direction);
                hitBoxScript.m_atkDamage = Mathf.RoundToInt(m_maxDamage * m_chargeRatio);
                hitBoxScript.m_isPassThroughPlayer = m_isPassThroughPlayers;
            }
            else
            {
                hitBoxScript.SetAttacker(playerController, direction);
                hitBoxScript.m_atkDamage = m_maxDamage;
                hitBoxScript.m_isPassThroughPlayer = m_isPassThroughPlayers;
            }
        }

        //scale anim
        StartCoroutine(Scale0To1());
    }

    /*----------------------------------------------------------*/

    private IEnumerator Scale0To1()
    {
        //Start at 10% of scale
        m_currentScaleTime = 0.1f * m_timeToMaxScale;

        while (m_currentScaleTime < m_timeToMaxScale)
        {
            //scale hitbox
            m_currentScaleTime += Time.deltaTime;
            m_currentScaleTime = Mathf.Clamp(m_currentScaleTime, 0, m_timeToMaxScale);
            transform.localScale = Vector3.one * (m_currentScaleTime / m_timeToMaxScale);

            yield return null;
        }
    }

    private void Move()
    {
        m_rb.velocity = m_direction * m_speed;
    }
}
