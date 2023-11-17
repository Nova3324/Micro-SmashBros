using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    //Control one player
    [HideInInspector] public PlayerInput m_playerInput;
    private PlayerController m_playerController;


    public Vector2 joystick;
    bool m_isJump;

    /*---------------------------------------------------------GAME---------------------------------------------------------*/
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
        if (context.performed)
        {
            m_playerController.PlayerJump();
        }
        if (context.canceled)
        {
            m_playerController.ResetJump();
        }
    }

    public void OnAtkDirection(InputAction.CallbackContext context)
    {
        m_playerController.AttackDirection(context.ReadValue<Vector2>());
    }

    public void OnBasicAtk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_playerController.LaunchBasicAtk();
        }
    }
    public void OnChargedAtk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_playerController.ChargeChargedAtk();

        }
        else if (context.canceled)
        {
            m_playerController.LaunchChargedAtk();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
            m_playerController.Pause();
    }

    public void Back(InputAction.CallbackContext context)
    {
        if(context.performed)
            m_playerController.BackSettings();
    }
}

