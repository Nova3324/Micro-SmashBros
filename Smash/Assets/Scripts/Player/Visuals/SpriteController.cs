using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [HideInInspector] public Animator m_animator;
    [SerializeField] private PlayerController m_playerController;

    public SpriteRenderer m_head;
    public SpriteRenderer m_body;
    public SpriteRenderer m_backHand;
    public SpriteRenderer m_frontHand;
    public SpriteRenderer m_backFoot;
    public SpriteRenderer m_frontFoot;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    public void WalkAnimation(float speed)
    {
        m_animator.SetBool("Walk", true);
        m_animator.SetFloat("Speed", speed / 5);
    }
}
