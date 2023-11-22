using UnityEngine;

public class ScriptableReader : MonoBehaviour
{
    [SerializeField] private PlayerInfo m_playerInfo;

    [HideInInspector] public float m_mass { get; private set; }
    [HideInInspector] public float m_maxSpeed { get; private set; }
    [HideInInspector] public float m_basicAttack { get; private set; }
    [HideInInspector] public float m_remoteAttack { get; private set; }
    [HideInInspector] public string m_name { get; private set; }

    [HideInInspector] public Sprite m_chargedAtkSprite { get; private set; }
    [HideInInspector] public Sprite m_head { get; private set; }

    void Awake()
    {
        m_mass = m_playerInfo.m_mass;
        m_maxSpeed = m_playerInfo.m_maxSpeed;
        m_basicAttack = m_playerInfo.m_basicAttack;
        m_remoteAttack = m_playerInfo.m_remoteAttack;
        m_name = m_playerInfo.m_name;

        m_chargedAtkSprite = m_playerInfo.m_chargedAtkSp;
        m_head = m_playerInfo.m_head;
    }

    public void SetSprites(SpriteController sprites)
    {
        sprites.m_head.sprite = m_playerInfo.m_head;
        sprites.m_body.sprite = m_playerInfo.m_body;
        sprites.m_backHand.sprite = m_playerInfo.m_backHand;
        sprites.m_frontHand.sprite = m_playerInfo.m_frontHand;
        sprites.m_backFoot.sprite = m_playerInfo.m_backFoot;
        sprites.m_frontFoot.sprite = m_playerInfo.m_frontFoot;
    }
}
