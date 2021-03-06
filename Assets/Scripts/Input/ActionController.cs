// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/ActionController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionController"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""c4d86571-aab1-48ed-bc5d-94261ab49377"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""cc6795ef-49f0-43d5-8210-7cbc6383c464"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""83ac83e0-dbcf-4530-8d6d-e5beac1b592d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3fd42baa-d9fa-4d01-a315-f48b444d93c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a8307829-9f30-45da-a244-7da8ac58d5e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2395a335-f7fc-4a9a-b2a0-87559cd3d99f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b10331d7-516c-4f9d-8c47-e5f49807fc40"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3c24f3a3-dd94-45bb-8422-e8772e0d04e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""17af5365-e986-4533-94af-0203599a5daa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eb7f96a5-862d-4d54-b2d9-9ad164031e9d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""812c5ed5-f64f-455c-a3fd-5d2d4774b7b4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMap
        m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
        m_ActionMap_Move = m_ActionMap.FindAction("Move", throwIfNotFound: true);
        m_ActionMap_Fire = m_ActionMap.FindAction("Fire", throwIfNotFound: true);
        m_ActionMap_Pause = m_ActionMap.FindAction("Pause", throwIfNotFound: true);
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

    // ActionMap
    private readonly InputActionMap m_ActionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_ActionMap_Move;
    private readonly InputAction m_ActionMap_Fire;
    private readonly InputAction m_ActionMap_Pause;
    public struct ActionMapActions
    {
        private @ActionController m_Wrapper;
        public ActionMapActions(@ActionController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ActionMap_Move;
        public InputAction @Fire => m_Wrapper.m_ActionMap_Fire;
        public InputAction @Pause => m_Wrapper.m_ActionMap_Pause;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFire;
                @Pause.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ActionMapActions @ActionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
