using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] PlayerMovement m_playerMovement;
    [SerializeField] private int m_collisionCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Solid")))
        {
            m_collisionCount++;
            m_playerMovement.m_isGrounded = true;
            m_playerMovement.m_isJumping = false;
            m_playerMovement.m_currentKnockback *= Vector2.right;
            m_playerMovement.m_jumpCount = 0;          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Solid")))
        {
            m_collisionCount--;

            if (m_collisionCount == 0)
            {
                m_playerMovement.m_isGrounded = false;
            }
        }
    }
}
