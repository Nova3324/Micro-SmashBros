using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [HideInInspector] public Animator m_animator;
    [SerializeField] private PlayerController m_playerController;

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
