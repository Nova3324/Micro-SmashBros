using UnityEngine;

[RequireComponent (typeof(PlayerMovement),typeof(BasicAttack))]
[RequireComponent(typeof(ChargedAttack), typeof(Parade), typeof(ScriptableReader))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    BasicAttack m_basicAttack;
    ChargedAttack m_chargedAttack;
    Parade m_parade;

    public PlayerLife m_playerLife { get; private set; }
    public PlayerMovement m_playerMovement { get; private set; }
    public ScriptableReader m_playerStats { get; private set; }

    //respawn
    public Vector3 m_spawnPos { get; private set; }

    /*----------------------------------------------------------*/

    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();        
        m_basicAttack = GetComponent<BasicAttack>();        
        m_chargedAttack = GetComponent<ChargedAttack>();        
        m_parade = GetComponent<Parade>();  
        m_playerStats = GetComponent<ScriptableReader>();
        
        m_playerLife = new PlayerLife(this, transform.parent); 
        
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
        m_playerMovement.Jump();
    }

    public void AttackDirection(Vector2 direction)
    {
        m_basicAttack.SetAttackDirection(direction);
    }

    public void LauchBasicAtk()
    {
        m_basicAttack.LaunchAttack();
    }
}
