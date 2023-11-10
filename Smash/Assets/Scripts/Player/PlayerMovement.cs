using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableReader m_scriptableReader;
    [SerializeField] DetectCollisions m_detectCollisions;
    
    Rigidbody2D m_rigidbody;

    public bool m_isStatic;
    [SerializeField] Vector2 m_gravity = new Vector2 (0f, -9.81f);
    [SerializeField] Vector2 m_currentGravity;
    Transform m_pos;
    
    void Start()
    {
        m_rigidbody = GetComponentInParent<Rigidbody2D>();
        m_isStatic =  false;

        m_currentGravity = m_gravity;
        m_pos = transform.parent;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    public void Move(Vector2 vector2)
    {
        if(!m_isStatic) 
        {
            vector2.Set(vector2.x * m_scriptableReader.m_maxSpeed, m_rigidbody.velocity.y);
            m_rigidbody.velocity = vector2;
        }
    }

    public void Gravity()
    {
        if(m_detectCollisions.GetIsGrounded())
        {
            m_currentGravity = Vector2.zero;
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, 0f);
            m_pos.position = new Vector3(m_pos.position.x, m_pos.position.y + m_detectCollisions.m_downOffset, m_pos.position.z);
        }
        else
        {
            m_currentGravity = m_gravity;
            m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
        }

    }
}
