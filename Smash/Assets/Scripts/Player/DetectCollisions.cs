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
        float distance = m_capsuleCollider.bounds.size.y/2f;
        
        //Raycast on the right
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + m_raycastOffsetX, Vector2.down, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position + m_raycastOffsetX, Vector2.down * distance, Color.red);

        //Raycast on the left
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - m_raycastOffsetX, Vector2.down, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position - m_raycastOffsetX, Vector2.down * distance, Color.red);
        
        if (hitRight.collider != null)
        {
            m_downOffset = distance - hitRight.distance;
            return true;
        }
        else if(hitLeft.collider != null)
        {
            m_downOffset = distance - hitLeft.distance;
            return true;
        }
        else 
            return false;
    }

    /*-----------------------------------------------------------RIGHT RAYCAST-----------------------------------------------------------*/
    public bool IsThereWallOnTheRight()
    {
        m_rightOffset = 0;
        float distance = m_capsuleCollider.bounds.size.x / 2;

        //up Raycast
        RaycastHit2D rightHitUp = Physics2D.Raycast(transform.position + m_raycastOffsetY, Vector2.right, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position + m_raycastOffsetY, Vector2.right * distance, Color.yellow);

        //middle Raycast
        RaycastHit2D rightHitMiddle = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.yellow);

        //down Raycast
        RaycastHit2D rightHitDown = Physics2D.Raycast(transform.position - m_raycastOffsetY, Vector2.right, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position - m_raycastOffsetY, Vector2.right * distance, Color.yellow);
        if (rightHitUp.collider != null)
        {
            //m_rightOffset = distance - rightHitUp.distance;
            return true;
        }
        else if (rightHitMiddle.collider != null)
        {
            //m_rightOffset = distance - rightHitMiddle.distance;
            return true;
        }
        else if (rightHitDown.collider != null)
        {
            //_rightOffset = distance - rightHitDown.distance;
            return true;
        }
        else
        {
            return false;
        }
    }

    /*-----------------------------------------------------------LEFT RAYCAST-----------------------------------------------------------*/
    public bool IsThereWallOnTheLeft()
    {
        m_leftOffset = 0;
        float distance = m_capsuleCollider.bounds.size.x / 2;

        //up Raycast
        RaycastHit2D leftHitUp = Physics2D.Raycast(transform.position + m_raycastOffsetX, Vector2.left, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position + m_raycastOffsetY, Vector2.left * distance, Color.yellow);

        //middle Raycast
        RaycastHit2D leftHitMiddle = Physics2D.Raycast(transform.position, Vector2.left, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position, Vector2.left * distance, Color.yellow);

        //down Raycast
        RaycastHit2D leftHitDown = Physics2D.Raycast(transform.position - m_raycastOffsetY, Vector2.left, distance, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position - m_raycastOffsetY, Vector2.left * distance, Color.yellow);

        if (leftHitUp.collider != null)
        {
            m_leftOffset = distance - leftHitUp.distance;
            return true;
        }
        else if (leftHitMiddle.collider != null)
        {
            m_leftOffset = distance - leftHitMiddle.distance;
            return true;
        }
        else if (leftHitDown.collider != null)
        {
            m_leftOffset = distance - leftHitDown.distance;
            return true;
        }
        else
        {
            return false;
        }
    }
}
