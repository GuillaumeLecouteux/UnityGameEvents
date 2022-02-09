using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear.UnityGameEvents
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private GameEvent _event;
        
        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            if(_response != null)
                _response.Invoke();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}