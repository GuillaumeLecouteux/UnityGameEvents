namespace JauntyBear.UnityGameEvents
{
    public interface IGameEvent<T>
    {
        void Raise(T eventParameter);
    }

    public interface IGameEvent
    {
        void Raise();
    }
}