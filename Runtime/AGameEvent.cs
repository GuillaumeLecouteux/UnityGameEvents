using System.Collections.Generic;
using UnityEngine;

namespace JauntyBear.UnityGameEvents
{
    public abstract class AGameEvent : ScriptableObject, IGameEvent
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IGameEventListener> _eventListeners =
            new List<IGameEventListener>();

        public List<IGameEventListener> EventListeners => _eventListeners;

        public void Raise()
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    public abstract class AGameEvent<T> : ScriptableObject, IGameEvent<T>
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        public T eventParameter;
        private readonly List<IGameEventListener<T>> _eventListeners =
            new List<IGameEventListener<T>>();
        public List<IGameEventListener<T>> EventListeners => _eventListeners;

        public void Raise(T newEventParameter)
        {
            this.eventParameter = newEventParameter;
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(this.eventParameter);
        }

        public void Raise()
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(eventParameter);
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}