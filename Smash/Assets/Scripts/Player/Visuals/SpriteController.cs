using System.Collections;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public Animator m_animator;
    [SerializeField] private PlayerController m_playerController;

    [Header("Colors")]
    [SerializeField] private Color32 m_stunColor;
    [SerializeField] private Color32 m_hitColor;
    private float m_hitTime = 0.1f;

    [Header("Sprites")]
    public SpriteRenderer m_head;
    public SpriteRenderer m_body;
    public SpriteRenderer m_backHand;
    public SpriteRenderer m_backFoot;
    public SpriteRenderer m_frontHand;
    public SpriteRenderer m_frontFoot;

    /*----------------------------------------------------------*/

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    /*----------------------------------------------------------*/

    public void StopUpLaunchAtack() 
    {
        m_animator.SetBool("Up Launch Attack", false);
    }

    public void WalkAnimation(float speed)
    {
        m_animator.SetBool("Walk", true);
        m_animator.SetFloat("Speed", speed / 5);
    }

    public void StunColor(float stunDuration)
    {
        StopAllCoroutines();
        StartCoroutine(HitColorChange(stunDuration));
    }

    public void InvicibleColor(float invicibleDuration)
    {
        StopAllCoroutines();
        StartCoroutine(IncincibilityColorChange(invicibleDuration));
    }

    /*----------------------------------------------------------*/

    private void ChangeColor(Color32 color)
    {
        m_head.color = color;
        m_body.color = color;
        m_backHand.color = color;
        m_backFoot.color = color;
        m_frontHand.color = color;
        m_frontFoot.color = color;
    }

    private IEnumerator HitColorChange(float stunDuration)
    {
        ChangeColor(m_hitColor);

        yield return new WaitForSeconds(m_hitTime);

        ChangeColor(m_stunColor);

        yield return new WaitForSeconds(stunDuration);

        ChangeColor(Color.white);
    }

    private IEnumerator IncincibilityColorChange(float invicibleDuration)
    {
        float dt = 0f;
        float lerpIndex;

        while (dt < invicibleDuration)
        {
            dt += Time.deltaTime;

            lerpIndex = Mathf.PingPong(dt * 2f, 1f);
            ChangeColor(Color32.Lerp(Color.white, m_stunColor, lerpIndex));

            yield return null;
        }

        ChangeColor(Color.white);
    }
}
