using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class PlayerInfo : ScriptableObject
{
    public float m_mass;
    public float m_maxSpeed;
    public float m_basicAttack;
    public float m_remoteAttack;

    public string m_name;
}
