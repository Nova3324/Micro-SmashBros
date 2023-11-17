using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> m_spriteRenderer = new List<SpriteRenderer>();
    [HideInInspector] public Animator m_animator;
    [SerializeField] private PlayerController m_playerController;

    void Start()
    {
        for(int i = 0;  i < transform.childCount; i++) 
        {
            SpriteRenderer spriteRenderer = transform.GetChild(i).GetComponentInChildren<SpriteRenderer>();
            var child = transform.GetChild(i);
            
            if(spriteRenderer != null)
            {
                m_spriteRenderer.Add(spriteRenderer);
            }

            for(int j = 0; j < child.childCount; j++)
            {
                SpriteRenderer spriteRendererInChildren = child.GetChild(j).GetComponentInChildren<SpriteRenderer>();
                if (spriteRendererInChildren != null)
                {
                    m_spriteRenderer.Add(spriteRendererInChildren);
                }
            }
        }    
    }

    public void WalkAnimation(float speed)
    {
        m_animator.SetBool("Walk", true);
        m_animator.SetFloat("Speed", speed / 5);
    }
}
