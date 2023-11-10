using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerMovement),typeof(BasicAttack))]
[RequireComponent(typeof(RemoteAttack), typeof(Parade), typeof(ScriptableReader))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    PlayerMovement m_playerMovement;
    PlayerLife m_playerLife;
    BasicAttack m_basicAttack;
    RemoteAttack m_remoteAttack;
    Parade m_parade;
    ScriptableReader m_playerStats;

    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();        
        m_basicAttack = GetComponent<BasicAttack>();        
        m_remoteAttack = GetComponent<RemoteAttack>();        
        m_parade = GetComponent<Parade>();  
        m_playerStats = GetComponent<ScriptableReader>();
        
        m_playerLife = new PlayerLife(m_playerStats, m_playerMovement);        
    }

    public void PlayerMovement(Vector2 vector2)
    {
        m_playerMovement.Move(vector2);
    }
}
