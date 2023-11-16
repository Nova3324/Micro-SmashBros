using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(BasicAttack))]
[RequireComponent(typeof(ChargedAttack), typeof(Parade), typeof(ScriptableReader))]
public class PlayerController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject m_UIpersonnage;

    [Header("Player Components")]
    BasicAttack m_basicAttack;
    ChargedAttack m_chargedAttack;
    Parade m_parade;

    public PlayerLife m_playerLife { get; private set; }
    public PlayerMovement m_playerMovement { get; private set; }
    public ScriptableReader m_playerStats { get; private set; }

    //respawn
    [HideInInspector] public Vector3 m_spawnPos { get; private set; }

    private bool m_isCanAct = true;

    /*----------------------------------------------------------*/

    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_basicAttack = GetComponent<BasicAttack>();
        m_chargedAttack = GetComponent<ChargedAttack>();
        m_parade = GetComponent<Parade>();
        m_playerStats = GetComponent<ScriptableReader>();

        m_playerLife = new PlayerLife(this, transform.parent, m_UIpersonnage);

        m_spawnPos = transform.parent.position;
    }

    private void Update()
    {
        m_playerLife.IsKickedOut();
        m_chargedAttack.UpdtChargement();
    }

    /*----------------------------------------------------------*/

    public void PlayerMovement(Vector2 vector2)
    {
        m_playerMovement.Move(vector2);
        m_playerMovement.JoystickDirection(vector2);
    }

    public void PlayerJump()
    {
        if (m_isCanAct)
        {
            m_playerMovement.Jump();
        }
    }

    public void ResetJump()
    {
        if (m_isCanAct)
        {
            m_playerMovement.ResetTimeToReachMaxHeight();
        }
    }

    public void AttackDirection(Vector2 direction)
    {
        if (m_isCanAct)
        {
            m_basicAttack.SetAttackDirection(direction);
            m_chargedAttack.SetAttackDirection(direction);
        }
    }

    public void LaunchBasicAtk()
    {
        if (m_isCanAct)
        {
            m_playerLife.m_isInvicible = false;
            m_basicAttack.LaunchAttack();
        }
    }

    public void ChargeChargedAtk()
    {
        if (m_isCanAct)
        {
            m_playerLife.m_isInvicible = false;
            m_chargedAttack.StartAtkChargement();
        }
    }

    public void LaunchChargedAtk()
    {
        if (m_isCanAct)
        {
            m_chargedAttack.LaunchAtk();
        }
    }

    /*----------------------------------------------------------*/

    public void BecomeInvicible()
    {
        StartCoroutine(InvincibleDuring(3f));
    }

    public void Stun(float duration)
    {
        StartCoroutine(CantActDuring(duration));
    }

    /*----------------------------------------------------------*/

    private IEnumerator InvincibleDuring(float duration)
    {
        m_playerLife.m_isInvicible = true;
        yield return new WaitForSeconds(duration);
        m_playerLife.m_isInvicible = false;
    }

    private IEnumerator CantActDuring(float duration)
    {
        m_isCanAct = false;
        m_playerMovement.m_isStatic = true;
        yield return new WaitForSeconds(duration);
        m_isCanAct = true;
        m_playerMovement.m_isStatic = false;
    }
}
