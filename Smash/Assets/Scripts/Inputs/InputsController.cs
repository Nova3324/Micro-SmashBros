using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    //Control one player
    private PlayerInput m_playerInput;
    private PlayerController m_playerController;

    void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_playerController = PlayerManager.Instance.m_playerControllers[m_playerInput.playerIndex];
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 stick = context.ReadValue<Vector2>();
        m_playerController.PlayerMovement(stick);
    }
}

