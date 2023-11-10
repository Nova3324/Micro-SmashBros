using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    public PlayerInfo m_playerInfo;

    public float m_mass;
    public float m_maxSpeed;
    public float m_basicAttack;
    public float m_remoteAttack;

    void Start()
    {
        m_mass = m_playerInfo.m_mass;
        m_maxSpeed = m_playerInfo.m_maxSpeed;
        m_basicAttack = m_playerInfo.m_basicAttack;
        m_remoteAttack = m_playerInfo.m_remoteAttack;
    }
}
