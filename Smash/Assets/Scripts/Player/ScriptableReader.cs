using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    [SerializeField] private PlayerInfo m_playerInfo;

    [HideInInspector] public float m_mass { get; private set; }
    [HideInInspector] public float m_maxSpeed { get; private set; }
    [HideInInspector] public float m_basicAttack { get; private set; }
    [HideInInspector] public float m_remoteAttack { get; private set; }
    [HideInInspector] public string m_name { get; private set; }

    void Awake()
    {
        m_mass = m_playerInfo.m_mass;
        m_maxSpeed = m_playerInfo.m_maxSpeed;
        m_basicAttack = m_playerInfo.m_basicAttack;
        m_remoteAttack = m_playerInfo.m_remoteAttack;
        m_name = m_playerInfo.m_name;
    }
}
