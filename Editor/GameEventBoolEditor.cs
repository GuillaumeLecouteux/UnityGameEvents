using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityGameEvents
{
    [CustomEditor(typeof(GameEventBool))]
    public class GameEventBoolEditor : Editor
    {
        private GameEventBool _target;
        private bool _eventValue;

        public void OnEnable()
        {
            _target = (GameEventBool)target;
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

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Raise Game Event with Parameter"))
                _target.Raise(_eventValue);
            _eventValue = EditorGUILayout.Toggle(string.Empty, _eventValue);
            EditorGUILayout.EndHorizontal();
        }
    }
}