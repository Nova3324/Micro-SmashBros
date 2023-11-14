using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D m_capsuleCollider;
    public float m_downOffset;
    public float m_rightOffset;
    public float m_leftOffset;
    private Vector3 m_raycastOffsetX;
    private Vector3 m_raycastOffsetY;

    private void Start()
    {
        m_raycastOffsetX = new Vector3(m_capsuleCollider.bounds.size.x/2f * 0.90f, 0f, 0f);
        m_raycastOffsetY = new Vector3(0f, m_capsuleCollider.bounds.size.y / 2 * 0.90f, 0f);
    }

    public bool GetIsGrounded()
    {
        m_downOffset = 0;
        float distance = m_capsuleCollider.bounds.size.y * 0.51f;
        
        //Raycast on the right
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + m_raycastOffsetX, Vector2.down, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position + m_raycastOffsetX, Vector2.down * distance, Color.red);

        //Raycast on the left
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - m_raycastOffsetX, Vector2.down, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position - m_raycastOffsetX, Vector2.down * distance, Color.red);
        
        if (hitRight.collider != null)
        {
            return true;
        }
        else if(hitLeft.collider != null)
        {            return true;
        }
        else 
            return false;
    }
}
