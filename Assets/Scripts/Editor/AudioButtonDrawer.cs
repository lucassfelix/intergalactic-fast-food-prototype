using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioButton))]
[CanEditMultipleObjects]
public class AudioButtonDrawer : UnityEditor.UI.ButtonEditor
{
    private SerializedProperty _audioButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        _audioButton = serializedObject.FindProperty("clickAudioEvent");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        serializedObject.Update();
        EditorGUILayout.PropertyField(_audioButton);
        serializedObject.ApplyModifiedProperties();
    }
}
