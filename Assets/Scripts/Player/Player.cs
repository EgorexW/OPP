public class Player : ObjectRoot<IPlayerComponent>, IPlayer{
        
}

public interface IPlayer : IObjectRoot<IPlayerComponent>{
    
}

public interface IPlayerComponent{ }