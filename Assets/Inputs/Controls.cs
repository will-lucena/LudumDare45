// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""6c9cb058-1126-41c4-a4ff-654211ad68ae"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""7261b9d5-457f-4720-9608-59f84af41058"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""bbd532ec-3830-4006-87fd-31b96d7a1021"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""afb8cd6e-24e2-4695-aaf8-f0ebf6d685b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""5bd2fa4c-536c-4c1d-9247-993d26ec7e4c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""dbdbd70d-dc0a-47b1-a402-ae944cc1bdf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToMainWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""c7c53c53-7f9a-475c-9b1b-6437e9c6e9b5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToSecondaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""f3b8b3be-5996-4a87-869f-6207427d29d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CollectWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""6b1a4e1d-c81b-425a-80c8-8d45f1547958"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0728b5a6-efb6-4c43-9410-442779faf4ee"",
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
                    ""id"": ""6dc58afe-9e41-49f4-b7e8-49048ca71fbf"",
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
                    ""id"": ""2343fb7f-984b-473a-b0f1-cd3295b05f6d"",
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
                    ""id"": ""6cd7c71a-309f-4d21-98a8-24102d03d5f5"",
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
                    ""id"": ""271787bc-719a-4a64-971f-46232e971aba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""2b1737c4-add5-4fa7-a97e-4c827cbbe73e"",
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
                    ""id"": ""cbe865a8-f1e3-4a39-a477-47927205eef5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e0f1cd5-74c9-4910-a9ba-f285d5596378"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6fdfdb4f-ee07-4ff5-a429-ce6b31cc4061"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0351394-db60-4aab-b58f-39e374bec453"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""65c59327-b97b-4fc4-bfb2-34ec7e26b6e9"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4e99138-bcf4-4438-b7a7-f4354bb588d5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2728bcd9-b1f1-40cd-812e-a5fdf74776c6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7df5f693-fd73-4cb4-b20a-9ff5fb431cff"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ce58f5a-ff14-4ad7-9639-78727f135c78"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToSecondaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1379e9-c48e-4564-a976-ddbe9b0ce424"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToSecondaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c3ee680-5756-4338-885a-1bf0211d1709"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToMainWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""148c3450-903e-4f6a-9d5b-03be49c41846"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToMainWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""335872a1-e5ad-459d-a806-aca53c7b581f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CollectWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Move = m_PlayerControl.FindAction("Move", throwIfNotFound: true);
        m_PlayerControl_Aim = m_PlayerControl.FindAction("Aim", throwIfNotFound: true);
        m_PlayerControl_Shoot = m_PlayerControl.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerControl_Reload = m_PlayerControl.FindAction("Reload", throwIfNotFound: true);
        m_PlayerControl_ChangeWeapon = m_PlayerControl.FindAction("ChangeWeapon", throwIfNotFound: true);
        m_PlayerControl_ChangeToMainWeapon = m_PlayerControl.FindAction("ChangeToMainWeapon", throwIfNotFound: true);
        m_PlayerControl_ChangeToSecondaryWeapon = m_PlayerControl.FindAction("ChangeToSecondaryWeapon", throwIfNotFound: true);
        m_PlayerControl_CollectWeapon = m_PlayerControl.FindAction("CollectWeapon", throwIfNotFound: true);
    }

    ~Controls()
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Move;
    private readonly InputAction m_PlayerControl_Aim;
    private readonly InputAction m_PlayerControl_Shoot;
    private readonly InputAction m_PlayerControl_Reload;
    private readonly InputAction m_PlayerControl_ChangeWeapon;
    private readonly InputAction m_PlayerControl_ChangeToMainWeapon;
    private readonly InputAction m_PlayerControl_ChangeToSecondaryWeapon;
    private readonly InputAction m_PlayerControl_CollectWeapon;
    public struct PlayerControlActions
    {
        private Controls m_Wrapper;
        public PlayerControlActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControl_Move;
        public InputAction @Aim => m_Wrapper.m_PlayerControl_Aim;
        public InputAction @Shoot => m_Wrapper.m_PlayerControl_Shoot;
        public InputAction @Reload => m_Wrapper.m_PlayerControl_Reload;
        public InputAction @ChangeWeapon => m_Wrapper.m_PlayerControl_ChangeWeapon;
        public InputAction @ChangeToMainWeapon => m_Wrapper.m_PlayerControl_ChangeToMainWeapon;
        public InputAction @ChangeToSecondaryWeapon => m_Wrapper.m_PlayerControl_ChangeToSecondaryWeapon;
        public InputAction @CollectWeapon => m_Wrapper.m_PlayerControl_CollectWeapon;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                Aim.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                Aim.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                Aim.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                Shoot.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                Reload.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnReload;
                Reload.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnReload;
                Reload.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnReload;
                ChangeWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeWeapon;
                ChangeWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeWeapon;
                ChangeWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeWeapon;
                ChangeToMainWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToMainWeapon;
                ChangeToMainWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToMainWeapon;
                ChangeToMainWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToMainWeapon;
                ChangeToSecondaryWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToSecondaryWeapon;
                ChangeToSecondaryWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToSecondaryWeapon;
                ChangeToSecondaryWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnChangeToSecondaryWeapon;
                CollectWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCollectWeapon;
                CollectWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCollectWeapon;
                CollectWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCollectWeapon;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Aim.started += instance.OnAim;
                Aim.performed += instance.OnAim;
                Aim.canceled += instance.OnAim;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Reload.started += instance.OnReload;
                Reload.performed += instance.OnReload;
                Reload.canceled += instance.OnReload;
                ChangeWeapon.started += instance.OnChangeWeapon;
                ChangeWeapon.performed += instance.OnChangeWeapon;
                ChangeWeapon.canceled += instance.OnChangeWeapon;
                ChangeToMainWeapon.started += instance.OnChangeToMainWeapon;
                ChangeToMainWeapon.performed += instance.OnChangeToMainWeapon;
                ChangeToMainWeapon.canceled += instance.OnChangeToMainWeapon;
                ChangeToSecondaryWeapon.started += instance.OnChangeToSecondaryWeapon;
                ChangeToSecondaryWeapon.performed += instance.OnChangeToSecondaryWeapon;
                ChangeToSecondaryWeapon.canceled += instance.OnChangeToSecondaryWeapon;
                CollectWeapon.started += instance.OnCollectWeapon;
                CollectWeapon.performed += instance.OnCollectWeapon;
                CollectWeapon.canceled += instance.OnCollectWeapon;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    public interface IPlayerControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnChangeWeapon(InputAction.CallbackContext context);
        void OnChangeToMainWeapon(InputAction.CallbackContext context);
        void OnChangeToSecondaryWeapon(InputAction.CallbackContext context);
        void OnCollectWeapon(InputAction.CallbackContext context);
    }
}
