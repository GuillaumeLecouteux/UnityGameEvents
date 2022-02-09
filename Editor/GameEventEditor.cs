using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityGameEvents
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        private GameEvent _target;

        public void OnEnable()
        {
            _target = (GameEvent)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Name", _target.ToString());
            EditorGUILayout.LabelField("# Listeners", _target.EventListeners.Count.ToString());
            for (int i = _target.EventListeners.Count - 1; i >= 0; i--)
                EditorGUILayout.LabelField(i.ToString(), _target.EventListeners[i].ToString());
            
            if (GUILayout.Button("Raise Game Event"))
                _target.Raise();
        }
    }
}