using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    [SerializeField] PlayerController m_playerController;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 stick = context.ReadValue<Vector2>();
        m_playerController.PlayerMovement(stick);
    }
}

