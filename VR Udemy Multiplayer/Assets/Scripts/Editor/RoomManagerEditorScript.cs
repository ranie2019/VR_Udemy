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
        EditorGUILayout.HelpBox("Esse Script e Responsavel por crear e Juntar as Salas ", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("Entrar na Sala Aleatória "))  
        { 
            roomManager.JoinRandomRoom();
        }
    }
}
