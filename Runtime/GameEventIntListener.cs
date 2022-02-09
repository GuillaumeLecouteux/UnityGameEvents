using UnityEngine;
using System;
using UnityEngine.Events;

namespace JauntyBear.UnityGameEvents
{
    public class GameEventIntListener : MonoBehaviour, IGameEventListener<int>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private GameEventInt _gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent<int> _response;

        private void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(int arg)
        {
            if(_response != null)
                _response.Invoke(arg);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}