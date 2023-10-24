using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("Esse Script e Responsavel por criar e Juntar as Salas ", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;

      
        if (GUILayout.Button("Entrando em Uma Sala Escola"))
        {
            roomManager.OnEnterButtonClicked_School();
        }

        if (GUILayout.Button("Entrando em Uma Sala Ar Livre"))
        {
            roomManager.OnEnterButtonClicked_Outdoor();
        } 
    }
}
