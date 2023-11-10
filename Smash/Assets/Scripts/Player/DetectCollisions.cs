using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public float m_downOffset;
    private Vector3 m_raycastOffsetX = new Vector3(0.65f, 0f, 0f);

    private void Update()
    {
    }
    public bool GetIsGrounded()
    {
        m_downOffset = 0;
        float distance = transform.position.y - transform.parent.position.y;
        //Raycast on the right
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + m_raycastOffsetX, Vector2.down, distance, LayerMask.NameToLayer("Grounded"));
        Debug.DrawRay(transform.position + new Vector3(0.65f, 0f, 0f), Vector2.down, Color.red);

        //Raycast on the left
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - m_raycastOffsetX, Vector2.down, distance, LayerMask.NameToLayer("Grounded"));
        Debug.DrawRay(transform.position + new Vector3(-0.65f, 0f, 0f), Vector2.down, Color.red);
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
}
