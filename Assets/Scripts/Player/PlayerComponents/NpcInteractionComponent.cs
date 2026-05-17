using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class NpcInteractionComponent : MonoBehaviour, IPlayerComponent{
    [BoxGroup("References")] [Required] [SerializeField] FirstPersonController firstPersonController;
    [BoxGroup("References")][Required][SerializeField] PlayerInputPresenter  playerInputPresenter;
    [BoxGroup("References")] [Required] [SerializeField] PlayerInteraction playerInteraction;
    
    NpcInteractive npcInteractive;

    [FoldoutGroup("Events")] public UnityEvent<NpcInteractive> onNewInteractive = new();
    [FoldoutGroup("Events")] public UnityEvent onInteractionEnded = new();

    [SerializeField] float maxInteractDis = 4f;

    void Awake(){
        firstPersonController.onMove.AddListener(OnMove);
        playerInputPresenter.onNrInputPerformed.AddListener(OnNrInput);
        playerInteraction.onInteract.AddListener(OnAnyInteract);
    }

    void OnAnyInteract(IInteractive interactive){
        if (ReferenceEquals(interactive, npcInteractive)){
            return;
        }
        npcInteractive = null;
        onInteractionEnded.Invoke();
    }

    void OnNrInput(int arg0){
        if (npcInteractive == null){
            return;
        }
        var actions = npcInteractive.Actions;
        if (arg0 >= actions.Count){
            return;
        }
        var action = actions[arg0];
        npcInteractive.PerformAction(action);
    }

    void OnMove(Vector3 arg0){
        if (npcInteractive == null) return;
        var distance = Vector3.Distance(transform.position, npcInteractive.transform.position);
        if (distance > maxInteractDis){
            npcInteractive = null;
            onInteractionEnded.Invoke();
        }
    }

    public void InteractingWith(NpcInteractive npcInteractiveTmp){
        this.npcInteractive = npcInteractiveTmp;
        onNewInteractive.Invoke(npcInteractive);
    }
}