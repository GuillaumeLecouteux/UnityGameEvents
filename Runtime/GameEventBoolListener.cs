using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear.UnityGameEvents
{
    public class GameEventBoolListener : MonoBehaviour, IGameEventListener<bool>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private GameEventBool _gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent _responseOnTrue;
        [SerializeField] private UnityEvent _responseOnFalse;

        private void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(bool arg)
        {
            if (arg)
            {
                if (_responseOnTrue != null)
                    _responseOnTrue.Invoke();
            }
            else
            {
                if (_responseOnFalse != null)
                    _responseOnFalse.Invoke();
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}