using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    //Control one player
    private PlayerInput m_playerInput;
    private PlayerController m_playerController;

    public Vector2 joystick;
    bool m_isJump;

    void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_playerController = PlayerManager.Instance.m_playerControllers[m_playerInput.playerIndex];
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        joystick = context.ReadValue<Vector2>();
        m_playerController.PlayerMovement(joystick);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed) 
        {
            m_playerController.PlayerJump();
        }
    }
}

