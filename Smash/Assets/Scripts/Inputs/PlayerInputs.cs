//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Inputs/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""58c482ad-7e62-4499-9331-dc94665f2a86"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dd28efef-ab7a-4525-bbf6-8420c028141b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a7e26877-5383-4efb-bac6-cbea4feeb88d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Basic Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5d6544ba-3228-45be-94ce-cf5da5f94e0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Remote Attack"",
                    ""type"": ""Button"",
                    ""id"": ""261f5bb7-0107-4827-b398-28abc1b89dc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Parade"",
                    ""type"": ""Button"",
                    ""id"": ""458ec1e8-0af7-44b9-a0c9-4fd72adcd7a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""28801d7e-c65e-46e6-b3e1-d1c575986505"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""120bc7ae-7ef9-4780-a207-7c0a90d08e1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AtkDirection"",
                    ""type"": ""Value"",
                    ""id"": ""c7d1fa1b-c6d5-4c0e-9c71-ff499cdb276d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92b7d225-efaa-4f61-a0c3-1cb26f2b91d9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""159da204-7cd1-470d-8503-9c9c8214ce68"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45214551-ec34-42dc-aeb7-9496c2c004be"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06dade82-2e23-4ce5-80f8-cbe679469f83"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37fd2334-0efa-4eb3-b522-31605b6c10a1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1c50737-b6b4-42f4-8109-b17b365f9f8c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Remote Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9955ad32-5259-4768-84f9-d08eaaf748df"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Parade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba15b111-0716-40c4-b2c1-be89b6390caf"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Parade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7dbb273-aedb-4653-8c1f-edb8c536fa26"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bfab2c5-ffe7-4e68-8b96-d88ab7935132"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52fe3fb0-b20b-480b-bdca-187b006254c9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a1089cce-10e5-4264-b681-7bd88caf1408"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtkDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d8d7c14c-bd17-482c-ab33-4358aa0e98a4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AtkDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9b829087-f41f-4bac-9bdd-b432b4e48ca8"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AtkDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9714b624-60a9-4aa7-9db0-02f2b24981c9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AtkDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b3da9939-0ab1-41d3-9954-32056b1bd21b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AtkDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""afbb134f-65d4-401f-ac08-0dd893575188"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""386b3622-d657-415b-b005-fe5527307fd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9049af4a-fa48-4620-905b-aa6e1e72e0d7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_BasicAttack = m_Game.FindAction("Basic Attack", throwIfNotFound: true);
        m_Game_RemoteAttack = m_Game.FindAction("Remote Attack", throwIfNotFound: true);
        m_Game_Parade = m_Game.FindAction("Parade", throwIfNotFound: true);
        m_Game_Dash = m_Game.FindAction("Dash", throwIfNotFound: true);
        m_Game_Start = m_Game.FindAction("Start", throwIfNotFound: true);
        m_Game_AtkDirection = m_Game.FindAction("AtkDirection", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Back = m_Menus.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Game
    private readonly InputActionMap m_Game;
    private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_BasicAttack;
    private readonly InputAction m_Game_RemoteAttack;
    private readonly InputAction m_Game_Parade;
    private readonly InputAction m_Game_Dash;
    private readonly InputAction m_Game_Start;
    private readonly InputAction m_Game_AtkDirection;
    public struct GameActions
    {
        private @PlayerInputs m_Wrapper;
        public GameActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @BasicAttack => m_Wrapper.m_Game_BasicAttack;
        public InputAction @RemoteAttack => m_Wrapper.m_Game_RemoteAttack;
        public InputAction @Parade => m_Wrapper.m_Game_Parade;
        public InputAction @Dash => m_Wrapper.m_Game_Dash;
        public InputAction @Start => m_Wrapper.m_Game_Start;
        public InputAction @AtkDirection => m_Wrapper.m_Game_AtkDirection;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void AddCallbacks(IGameActions instance)
        {
            if (instance == null || m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @BasicAttack.started += instance.OnBasicAttack;
            @BasicAttack.performed += instance.OnBasicAttack;
            @BasicAttack.canceled += instance.OnBasicAttack;
            @RemoteAttack.started += instance.OnRemoteAttack;
            @RemoteAttack.performed += instance.OnRemoteAttack;
            @RemoteAttack.canceled += instance.OnRemoteAttack;
            @Parade.started += instance.OnParade;
            @Parade.performed += instance.OnParade;
            @Parade.canceled += instance.OnParade;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @AtkDirection.started += instance.OnAtkDirection;
            @AtkDirection.performed += instance.OnAtkDirection;
            @AtkDirection.canceled += instance.OnAtkDirection;
        }

        private void UnregisterCallbacks(IGameActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @BasicAttack.started -= instance.OnBasicAttack;
            @BasicAttack.performed -= instance.OnBasicAttack;
            @BasicAttack.canceled -= instance.OnBasicAttack;
            @RemoteAttack.started -= instance.OnRemoteAttack;
            @RemoteAttack.performed -= instance.OnRemoteAttack;
            @RemoteAttack.canceled -= instance.OnRemoteAttack;
            @Parade.started -= instance.OnParade;
            @Parade.performed -= instance.OnParade;
            @Parade.canceled -= instance.OnParade;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @AtkDirection.started -= instance.OnAtkDirection;
            @AtkDirection.performed -= instance.OnAtkDirection;
            @AtkDirection.canceled -= instance.OnAtkDirection;
        }

        public void RemoveCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameActions instance)
        {
            foreach (var item in m_Wrapper.m_GameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameActions @Game => new GameActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private List<IMenusActions> m_MenusActionsCallbackInterfaces = new List<IMenusActions>();
    private readonly InputAction m_Menus_Back;
    public struct MenusActions
    {
        private @PlayerInputs m_Wrapper;
        public MenusActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Menus_Back;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void AddCallbacks(IMenusActions instance)
        {
            if (instance == null || m_Wrapper.m_MenusActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenusActionsCallbackInterfaces.Add(instance);
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
        }

        private void UnregisterCallbacks(IMenusActions instance)
        {
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
        }

        public void RemoveCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenusActions instance)
        {
            foreach (var item in m_Wrapper.m_MenusActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenusActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenusActions @Menus => new MenusActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnRemoteAttack(InputAction.CallbackContext context);
        void OnParade(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnAtkDirection(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnBack(InputAction.CallbackContext context);
    }
}
