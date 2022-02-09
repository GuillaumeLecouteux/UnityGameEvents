namespace JauntyBear.UnityGameEvents
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
    
    public interface IGameEventListener<IGameEvent>
    {
        void OnEventRaised(IGameEvent gameEvent);
    }
}