using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [BoxGroup("References")][Required][SerializeField] Transform aim;
    [BoxGroup("References")][Required][SerializeField] Player player;
    
    [SerializeField] bool log;
    [SerializeField] float maxInteractDis = 3;

    IInteractive currentInteractive;

    public bool HasInteractive => currentInteractive != null;

    [FoldoutGroup("Events")] public UnityEvent<IInteractive> onInteract = new();

    void Update(){
        currentInteractive = GetInteractive();
    }

    IInteractive GetInteractive(){
        RaycastHit[] raycasts = new RaycastHit[10];
        IInteractive interactive = null;
        Physics.RaycastNonAlloc(new Ray(aim.position, aim.forward), raycasts, maxInteractDis);
        if (log){
            Debug.DrawRay(aim.position, aim.forward * maxInteractDis, Color.red, 3);
        }
        var closestDis = float.MaxValue;
        foreach (var raycast in raycasts){
            if (raycast.collider == null){
                continue;
            }
            var distance = Vector3.Distance(aim.position, raycast.point);
            if (distance > closestDis){
                continue;
            }
            var gameObjectTmp = raycast.collider.gameObject;
            if (raycast.collider.attachedRigidbody != null){
                gameObjectTmp = raycast.collider.attachedRigidbody.gameObject;
            }
            gameObjectTmp.TryGetComponent<IInteractive>(out var interactiveTmp);
            if (interactiveTmp != null){
                closestDis = distance;
                interactive = interactiveTmp;
            }
        }
        return interactive;
    }

    public void Interact(){
        if (currentInteractive == null){
            return;
        }
        currentInteractive.Interact(player);
        onInteract.Invoke(currentInteractive);
        if (log){
            Debug.Log($"Interacting with {currentInteractive}");
        }
    }
}