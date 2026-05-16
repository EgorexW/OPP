using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class NpcInteractive : MonoBehaviour, IInteractive{
    List<NpcAction> actions;
    public IReadOnlyList<NpcAction> Actions => actions.AsReadOnly();

    void Awake(){
        actions = new List<NpcAction>(GetComponentsInChildren<NpcAction>());
    }

    public void Interact(IPlayer player){
        var NpcInteraction = player.GetComponent<NpcInteractionComponent>();
        NpcInteraction.InteractingWith(this);
    }

    public void PerformAction(NpcAction action){
        if (!actions.Contains(action)){
            Debug.LogWarning($"Trying to perform action {action} that is not in the list of actions for {gameObject.name}");
            return;
        }
        action.Perform();
    }
}