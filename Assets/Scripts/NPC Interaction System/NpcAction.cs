using UnityEngine;

public abstract class NpcAction : MonoBehaviour{
    [SerializeField] new string name;
    
    public string Name => name;

    public abstract void Perform();
}
