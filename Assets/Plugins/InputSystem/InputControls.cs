//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Plugins/InputSystem/InputControls.inputactions
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

public partial class @InputControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""3d6b02ea-531e-4b7f-88d8-f585c66a6de1"",
            ""actions"": [
                {
                    ""name"": ""StartTheBall"",
                    ""type"": ""Button"",
                    ""id"": ""487509f8-0ba8-4600-8db5-bd823adec375"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovePad"",
                    ""type"": ""Value"",
                    ""id"": ""9a515e6c-a724-4c08-9027-cf9b1c5daef8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dba39b9c-8067-4e9f-8d20-d91bbc1517c0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartTheBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b77df08-f305-41fe-a2b9-95b52055bc0b"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartTheBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e3449bec-5e18-4007-bbd9-e2f0bc366b41"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""69212154-94fc-4101-a11a-2e66d65eb658"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44669714-ed36-4058-b553-7a9b9287fd1c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cdf76404-e531-47cc-b058-e4c8efb2f46a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""39f29c6f-bcf6-4504-8154-48af13e7b8dd"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_StartTheBall = m_GamePlay.FindAction("StartTheBall", throwIfNotFound: true);
        m_GamePlay_MovePad = m_GamePlay.FindAction("MovePad", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_StartTheBall;
    private readonly InputAction m_GamePlay_MovePad;
    public struct GamePlayActions
    {
        private @InputControls m_Wrapper;
        public GamePlayActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartTheBall => m_Wrapper.m_GamePlay_StartTheBall;
        public InputAction @MovePad => m_Wrapper.m_GamePlay_MovePad;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @StartTheBall.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnStartTheBall;
                @StartTheBall.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnStartTheBall;
                @StartTheBall.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnStartTheBall;
                @MovePad.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovePad;
                @MovePad.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovePad;
                @MovePad.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovePad;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartTheBall.started += instance.OnStartTheBall;
                @StartTheBall.performed += instance.OnStartTheBall;
                @StartTheBall.canceled += instance.OnStartTheBall;
                @MovePad.started += instance.OnMovePad;
                @MovePad.performed += instance.OnMovePad;
                @MovePad.canceled += instance.OnMovePad;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnStartTheBall(InputAction.CallbackContext context);
        void OnMovePad(InputAction.CallbackContext context);
    }
}
