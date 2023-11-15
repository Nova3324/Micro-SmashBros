using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableReader m_scriptableReader;
    [SerializeField] DetectCollisions m_detectCollisions;

    Rigidbody2D m_rigidbody;

    [Header("Gravity")]
    [SerializeField] private float m_gravityMultiplier;
    [SerializeField] Vector2 m_gravity;
    private Vector2 m_currentGravity;

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

    [HideInInspector] public bool m_isStatic = false;
    private Vector2 m_joystickDirection;


    void Start()
    {
        m_rigidbody = GetComponentInParent<Rigidbody2D>();

        m_currentGravity = m_gravity;
    }

    private void Update()
    {
        JumpTimer();
    }

    private void FixedUpdate()
    {
        Gravity();
        Movements();
    }

    public void JoystickDirection(Vector2 vector)
    {
        m_joystickDirection = vector;
    }

    public void Move(Vector2 vector2)
    {
        if (!m_isStatic)
        {
            m_lateralMove = vector2.x * m_scriptableReader.m_maxSpeed;
        }
    }

    private void Gravity()
    {
        //Gravity
        if (m_isJumping == false && m_isEndJumping == false)
        {
            if (m_isGrounded == true)
            {
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
        else if(m_rigidbody.velocity.y <= 0)
        {
            m_isEndJumping = false;
        }
        m_rigidbody.velocity += m_currentGravity * Time.deltaTime;
    }

    private void Movements()
    {
        if (!m_isStatic)
        {
            if (!m_isGrounded)
                m_rigidbody.velocity = new Vector2(m_lateralMove * m_airDrag, m_rigidbody.velocity.y);
            else
                m_rigidbody.velocity = new Vector2(m_lateralMove, m_rigidbody.velocity.y);
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

    public void ResetTimeToReachMaxHeight()
    {
        if(m_isJumping)
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
            m_currentGravity = new Vector2(m_rigidbody.velocity.x, -m_jumpForce / m_deltaMaxHeight);
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_jumpForce);
            
            
            m_jumpCount++;
            m_isJumping = true;
        }
    }

    public void SetPlayerIsStatic(bool isStatic)
    {
        m_isStatic = isStatic;

        //stop x move
        if (m_isStatic)
        {
            m_rigidbody.velocity = m_rigidbody.velocity * Vector2.up;
        }
    }
}
