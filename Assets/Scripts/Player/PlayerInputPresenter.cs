using System;
using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInputPresenter : MonoBehaviour
{
    [BoxGroup("References")][GetComponent][SerializeField] PlayerInput playerInput;

    void Awake()
    {
        var inputActions = playerInput.actions.FindActionMap("Player");
    }


    void OnDestroy()
    {
        var inputActions = playerInput.actions.FindActionMap("Player");
    }
}       