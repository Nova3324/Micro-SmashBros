using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class PlayerInfo : ScriptableObject
{
    public float m_mass;
    public float m_maxSpeed;
    public float m_basicAttack;
    public float m_remoteAttack;

    public string m_name;

    public Sprite m_chargedAtkSp;

    public Sprite m_head;
    public Sprite m_body;
    public Sprite m_backHand;
    public Sprite m_frontHand;
    public Sprite m_backFoot;
    public Sprite m_frontFoot;
}
