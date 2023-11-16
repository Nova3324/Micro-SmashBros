using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableReader m_scriptableReader;
    [SerializeField] DetectCollisions m_detectCollisions;

    private Rigidbody2D m_rigidbody;

    [Header("Gravity")]
    [SerializeField] private float m_gravityMultiplier;
    private Vector2 m_gravity;
    private Vector2 m_currentGravity;
    private float m_velocityY;

    [HideInInspector] public bool m_isGrounded = false;
    [SerializeField][Range(0, 1)] private float m_airDrag;
    private float m_lateralMove;

    [Header("Jump")]
    [SerializeField] private int m_maxJump = 2;
    [SerializeField] private float m_maxHeight = 3.5f;
    [SerializeField] private float m_deltaMaxHeight = 0.5f;
    [HideInInspector] public int m_jumpCount = 0;
    [HideInInspector] public bool m_isJumping = false;
    private float m_jumpForce = 0f; //Jump start speed
    private float m_timeToReachMaxHeight; 
    private bool m_isEndJumping = false;

    [HideInInspector] public bool m_isStatic { get; set; } = false;
    private Vector2 m_joystickDirection;

    [Header("KnockBack")]
    [SerializeField] private float m_knobackDrag = 0.3f;
    [HideInInspector] public Vector2 m_currentKnockback;
    private Vector2 m_maxKnockback;

    /*----------------------------------------------------------*/

    void Start()
    {
        m_rigidbody = GetComponentInParent<Rigidbody2D>();

        m_gravity = new Vector2(0f, -((m_maxHeight / m_deltaMaxHeight) * 2f / m_deltaMaxHeight) * 1.3f);
        m_currentGravity = m_gravity;
    }

    private void Update()
    {
        JumpTimer();
    }

    private void FixedUpdate()
    {
        Gravity();
        KnockbackDragByAxe(m_maxKnockback.x,ref m_currentKnockback.x);
        KnockbackDragByAxe(m_maxKnockback.y,ref m_currentKnockback.y);
        Movements();
    }

    /*----------------------------------------------------------*/

    public void JoystickDirection(Vector2 vector)
    {
        m_joystickDirection = vector;
    }

    public void Move(Vector2 vector2)
    {
        m_lateralMove = vector2.x * m_scriptableReader.m_maxSpeed;
    }

    public void ResetTimeToReachMaxHeight()
    {
        if (m_isJumping)
        {
            m_timeToReachMaxHeight = 1.5f;
            m_isJumping = false;
            m_isEndJumping = true;
            m_currentGravity += m_gravity;
        }
    }

    public void Jump()
    {
        if (m_jumpCount < m_maxJump && m_isStatic == false)
        {
            m_timeToReachMaxHeight = m_deltaMaxHeight;
            m_jumpForce = (m_maxHeight / m_deltaMaxHeight) * 2f;

            //jump gravity
            m_currentGravity = new Vector2(m_rigidbody.velocity.x, -m_jumpForce / m_deltaMaxHeight);

            //jump Y velocity
            m_velocityY = m_jumpForce;
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_velocityY);

            m_jumpCount++;
            m_isJumping = true;
        }
    }

    public void AddKnockBack(Vector2 velocity)
    {
        velocity *= -m_gravity.y * 0.1f;

        m_maxKnockback = velocity;
        m_currentKnockback = velocity;
        m_rigidbody.velocity = velocity;
    }

    public void ResetVelocity()
    {
        //reste move
        m_rigidbody.velocity = Vector2.zero;
        m_velocityY = 0;
        m_currentKnockback = Vector2.zero;
        m_maxKnockback = Vector2.zero;
        m_lateralMove = 0;

        //reset jump
        ResetTimeToReachMaxHeight();
        m_isEndJumping = false;
    }

    /*----------------------------------------------------------*/

    private void Gravity()
    {
        //can't move
        if (m_isStatic)
        {
            if (m_currentKnockback.y == 0)
            {
                m_velocityY = 0;
                m_currentGravity = Vector2.zero;
            }
        }
        //Gravity no jump
        else if (m_isJumping == false && m_isEndJumping == false)
        {
            if (m_isGrounded == true)
            {
                m_velocityY = 0;
                m_currentGravity = Vector2.zero;
            }
            else if (m_joystickDirection.y < 0)
            {
                m_currentGravity = m_gravity * (1 + m_gravityMultiplier * (-m_joystickDirection.y));
            }
            else 
            {
                m_currentGravity = m_gravity;
            }
        }
        //Gravity on jump
        else if (m_rigidbody.velocity.y <= 0)
        {
            m_isEndJumping = false;
        }

        //apply gravity
        m_velocityY += m_currentGravity.y * Time.deltaTime;
    }

    private void KnockbackDragByAxe(float maxKb, ref float currentKb)
    {

        //knockack positive on axe
        if (maxKb > 0 && currentKb > 0)
        {
            currentKb += m_gravity.y * m_knobackDrag * Time.deltaTime;
            if (currentKb < 0)
            {
                currentKb = 0;
            }
        }
        //knockback negative on axe
        else if (maxKb < 0 && currentKb < 0)
        {
            currentKb -= m_gravity.y * m_knobackDrag * Time.deltaTime;
            if (currentKb > 0)
            {
                currentKb = 0;
            }
        }
    }

    private void Movements()
    {
        if (!m_isStatic)
        {
            //air movements
            if (!m_isGrounded)
                m_rigidbody.velocity = new Vector2(m_currentKnockback.x + m_lateralMove * m_airDrag, m_velocityY + m_currentKnockback.y);
            //grounded movements
            else
                m_rigidbody.velocity = new Vector2(m_currentKnockback.x + m_lateralMove, m_velocityY + m_currentKnockback.y);
        }
        else
        {
            m_rigidbody.velocity = new Vector2(m_currentKnockback.x, m_velocityY + m_currentKnockback.y);
        }
    }

    private void JumpTimer()
    {
        if(m_isJumping)
        { 
            m_timeToReachMaxHeight -= Time.deltaTime;
            if (m_timeToReachMaxHeight <= 0 )
            {
                m_timeToReachMaxHeight = 1.5f;
                m_isJumping = false;
            }
        }
    }
}
