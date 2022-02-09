using UnityEngine;
using UnityEngine.Events;
using System;

namespace JauntyBear.UnityGameEvents
{
    public abstract class AGameEventListener<T, U> : MonoBehaviour, IGameEventListener<T> where U : AGameEvent<T>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private U _gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent<T> _response;

        [Tooltip("Action to invoke when Event is raised.")]
        public Action<T> action;

        private void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T arg = default)
        {
            if(action != null)
                action.Invoke(arg);
            if(_response != null)
                _response.Invoke(arg);
        }
    }
}