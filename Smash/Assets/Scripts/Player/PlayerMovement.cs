using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableReader m_scriptableReader;
    [SerializeField] DetectCollisions m_detectCollisions;

    Rigidbody2D m_rigidbody;

    [SerializeField] Vector2 m_gravity = new Vector2(0f, -9.81f);
    
    private Vector2 m_currentGravity;
    private Transform m_pos;

    public bool m_isStatic;
    public bool m_leftDirectionIsTrigger;
    public bool m_rightDirectionIsTrigger;

    //[SerializeField] bool m_isJump = false;

    void Start()
    {
        m_rigidbody = GetComponentInParent<Rigidbody2D>();
        m_isStatic = false;

        m_currentGravity = m_gravity;
        m_pos = transform.parent;

        GameObject objet = GameObject.Find("PbInputController");

        if (objet != null)
        {

        }
    }

    private void FixedUpdate()
    {
        Gravity();
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
        if (!m_isStatic)
        {
            vector2.Set(vector2.x * m_scriptableReader.m_maxSpeed, m_rigidbody.velocity.y);
            m_rigidbody.velocity = vector2;
        }
    }

    public void Gravity()
    {
        if (m_detectCollisions.GetIsGrounded())
        {
            m_currentGravity = Vector2.zero;
        }
        else
        {
            m_currentGravity = m_gravity;
            m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
        }

    }

    public void Jump()
    {
        Debug.Log("Jump");
    }
}
