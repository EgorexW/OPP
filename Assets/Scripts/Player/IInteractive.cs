public interface IInteractive
{
    public float HoldDuration{ get; }
    bool IsDummy => false;
    public void Interact(IPlayer player);
}

public struct DummyInteractive : IInteractive
{
    public readonly void Interact(IPlayer player) { }
    public bool IsDummy => true;

    public float HoldDuration => 0;
}

public interface IPlayer{
    // TODO Empty for Now
}