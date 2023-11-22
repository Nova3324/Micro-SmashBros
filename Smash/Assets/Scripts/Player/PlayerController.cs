using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement), typeof(BasicAttack), typeof(PlayerDrawStats))]
[RequireComponent(typeof(ChargedAttack), typeof(Parade), typeof(ScriptableReader))]
public class PlayerController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject m_pbUIpersoOdd;
    [SerializeField] private GameObject m_pbUIpersoEven;
    [SerializeField] private GameObject m_pbEndGame;
    private GameObject m_UIpersonnage;

    [Header("Player Components")]
    [SerializeField] private SpriteController m_spController;
    BasicAttack m_basicAttack;
    ChargedAttack m_chargedAttack;
    Parade m_parade;
    PauseController m_pauseController;

    public PlayerLife m_playerLife { get; private set; }
    public PlayerMovement m_playerMovement { get; private set; }
    public ScriptableReader m_playerStats { get; private set; }
    public PlayerDrawStats m_drawStats { get; private set; }

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
        m_drawStats = GetComponent<PlayerDrawStats>();
        m_pauseController = FindAnyObjectByType<PauseController>();

        m_playerLife = new PlayerLife(this, transform.parent, m_UIpersonnage);

        m_spawnPos = transform.parent.position;

        //apply player stats
        m_playerStats.SetSprites(m_spController);
        m_chargedAttack.m_spriteProjectile = m_playerStats.m_chargedAtkSprite;

        //Start play
        BecomeInvicible();
    }

    private void Update()
    {
        m_playerLife.IsKickedOut();
        m_chargedAttack.UpdtChargement();
    }

    /*----------------------------------------------------------*/

    public void SpawnUiStats(int playerIndex)
    {
        playerIndex += 1; //because start at 0
        int multiplicator;
        float xOffset;
        float x;
        RectTransform rectTrs;

        if (playerIndex % 2 == 0)
        {
            m_UIpersonnage = Instantiate(m_pbUIpersoEven, GameObject.Find("CanvasPersoUI").transform);
            multiplicator = (playerIndex - 2) / 2;
            rectTrs = m_UIpersonnage.GetComponent<RectTransform>();
            xOffset = (-rectTrs.anchoredPosition.x * 2f - rectTrs.rect.size.x) / 2f;
            x = rectTrs.anchoredPosition.x - (rectTrs.rect.size.x + xOffset) * multiplicator;
        }
        else
        {
            m_UIpersonnage = Instantiate(m_pbUIpersoOdd, GameObject.Find("CanvasPersoUI").transform);
            multiplicator = (playerIndex - 1) / 2;
            rectTrs = m_UIpersonnage.GetComponent<RectTransform>();
            xOffset = (rectTrs.anchoredPosition.x * 2f - rectTrs.rect.size.x) / 2f;
            x = rectTrs.anchoredPosition.x + (rectTrs.rect.size.x + xOffset) * multiplicator;
        }

        rectTrs = m_UIpersonnage.GetComponent<RectTransform>();
        rectTrs.anchoredPosition = new Vector2(x, rectTrs.anchoredPosition.y);
    }

    public void SpawnEngameMenu()
    {
        GameObject UIendgame = Instantiate(m_pbEndGame, GameObject.Find("CanvasFront").transform);
        m_pauseController.SwitchActionMap("Menu");

        Selectable continueSelectable = GameObject.Find("Main Menu").GetComponent<Selectable>();

        if (continueSelectable != null)
            continueSelectable.Select();
    }

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
        float invicibilityTime = 3f;
        m_spController.InvicibleColor(invicibilityTime);
        StartCoroutine(InvincibleDuring(invicibilityTime));
    }

    public void Stun(float duration)
    {
        m_spController.StunColor(duration);
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

    public void Pause()
    {
        m_pauseController.Back();
    }

    public void BackSettings()
    {
        m_pauseController.BackSettings();
    }
}
