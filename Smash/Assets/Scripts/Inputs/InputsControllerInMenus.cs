using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsControllerInMenus : MonoBehaviour
{
    [SerializeField] private ButtonIsSelected m_buttonIsSelected;

    public void Navigate(InputAction.CallbackContext context)
    {
        if(context.performed)
            m_buttonIsSelected.m_isNavigate = true;
        else
            m_buttonIsSelected.m_isNavigate = false;
    }
}
