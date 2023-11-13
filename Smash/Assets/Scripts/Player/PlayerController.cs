using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerMovement),typeof(BasicAttack))]
[RequireComponent(typeof(RemoteAttack), typeof(Parade), typeof(ScriptableReader))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    PlayerLife m_playerLife;
    BasicAttack m_basicAttack;
    RemoteAttack m_remoteAttack;
    Parade m_parade;

    public PlayerMovement m_playerMovement { get; private set; }
    public ScriptableReader m_playerStats { get; private set; }

    //respawn
    public Vector3 m_spawnPos { get; private set; }

    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();        
        m_basicAttack = GetComponent<BasicAttack>();        
        m_remoteAttack = GetComponent<RemoteAttack>();        
        m_parade = GetComponent<Parade>();  
        m_playerStats = GetComponent<ScriptableReader>();
        
        m_playerLife = new PlayerLife(this, transform.parent); 
        
        m_spawnPos = transform.parent.position;
    }

    public void PlayerMovement(Vector2 vector2)
    {
        m_playerMovement.Move(vector2);
    }
}
