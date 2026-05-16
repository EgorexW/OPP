using System;
using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInputPresenter : MonoBehaviour
{
    [BoxGroup("References")][GetComponent][SerializeField] PlayerInput playerInput;

    [BoxGroup("References")] [Required] [SerializeField] PlayerInteraction playerInteraction;

    [FoldoutGroup("Events")] public UnityEvent<int> onNrInputPerformed = new();

    void Awake()
    {
        var inputActions = playerInput.actions.FindActionMap("Player");
        inputActions.FindAction("Interact").performed += InteractPerformed;
        for (var i = 0; i < 10; i++){
            var i1 = i - 1;
            if (i1 < 0){
                i1 = 9;
            }
            inputActions.FindAction("Nr " + i).performed += (context) => NrPerformed(i1, context);
        }
    }

    void NrPerformed(int i, InputAction.CallbackContext context){
        // Debug.Log($"Nr performed {i}");
        onNrInputPerformed.Invoke(i);
    }

    void InteractPerformed(InputAction.CallbackContext obj){
        // Debug.Log($"Interact performed");
        playerInteraction.Interact();
    }
    
    void OnDestroy()
    {
        var inputActions = playerInput.actions.FindActionMap("Player");
        inputActions.FindAction("Interact").performed -= InteractPerformed;
    }
}       