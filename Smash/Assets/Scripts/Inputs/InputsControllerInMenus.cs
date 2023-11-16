using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsControllerInMenus : MonoBehaviour
{
    private MenuController m_menuController;
    [SerializeField] private ButtonIsSelected m_buttonIsSelected;
    private PlayerInput m_playerInput;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_menuController = GetComponent<MenuController>();  
    }

    public void Navigate(InputAction.CallbackContext context)
    {
        if(context.performed)
            m_buttonIsSelected.m_isNavigate = true;
        else
            m_buttonIsSelected.m_isNavigate = false;
    }
}
