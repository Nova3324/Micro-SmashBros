using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableReader m_scriptableReader;
    [SerializeField] DetectCollisions m_detectCollisions;
    
    Rigidbody2D m_rigidbody;

    public bool m_isStatic;
    [SerializeField] Vector2 m_gravity = new Vector2 (0f, -9.81f);
    [SerializeField] Vector2 m_currentGravity;
    Transform m_pos;

    public bool m_leftDirectionIsTrigger;
    public bool m_rightDirectionIsTrigger;
    
    void Start()
    {
        m_rigidbody = GetComponentInParent<Rigidbody2D>();
        m_isStatic =  false;

        m_currentGravity = m_gravity;
        m_pos = transform.parent;

        GameObject objet = GameObject.Find("PbInputController");

        if(objet != null) 
        { 
            
        }
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
        WallsCollisions();
    }

    public void JoystickDirection(Vector2 vector)
    {
        if (vector.x < 0)
        {
            m_leftDirectionIsTrigger = true;
            m_rightDirectionIsTrigger = false;
        }
        else if (vector.x > 0) 
        {
            m_leftDirectionIsTrigger = false;
            m_rightDirectionIsTrigger = true;
        }
        else
        {
            m_leftDirectionIsTrigger = false;
            m_rightDirectionIsTrigger = false;
        }
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
            m_pos.position = new Vector3(m_pos.position.x, m_pos.position.y + m_detectCollisions.m_downOffset * 0.5f, m_pos.position.z);
        }
        else
        {
            m_currentGravity = m_gravity;
            m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
        }

    }

    public void WallsCollisions()
    {
        if(m_detectCollisions.IsThereWallOnTheRight()) 
        {
            if(m_leftDirectionIsTrigger)
            {
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y);
            }
            else
            {
                Debug.Log("collision with right wall");
                m_rigidbody.velocity = Vector2.zero;
                m_currentGravity = m_gravity;
                m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
            }
        }
        
        if(m_detectCollisions.IsThereWallOnTheLeft())
        {
            if (m_rightDirectionIsTrigger)
            {
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y);
            }
            else
            {
                Debug.Log("collision with left wall");
                m_rigidbody.velocity = Vector2.zero;
                m_currentGravity = m_gravity;
                m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
            }
        }
    }
}
