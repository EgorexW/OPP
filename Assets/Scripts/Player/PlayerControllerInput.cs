using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

    public class PlayerControllerInput : MonoBehaviour
    {
        [BoxGroup("References")][GetComponent][SerializeField] PlayerInput playerInput;
        
        [Header("Player Input Values")] public Vector2 move;

        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")] public bool analogMovement;

        void Awake()
        {
            var actionMap = playerInput.actions.FindActionMap("Player");
            actionMap.FindAction("Move").performed += OnMove;
            actionMap.FindAction("Look").performed += OnLook;
        }
        
        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            if (!value.performed){
                return;
            }
            MoveInput(value.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext value)
        {
            if (!value.performed){
                return;
            }
            LookInput(value.ReadValue<Vector2>());
        }
    }
