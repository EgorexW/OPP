using UnityEngine;

public class TestNpcAction : NpcAction{
    public override void Perform(){
        Debug.Log($"Action {Name} performed");
    }
}