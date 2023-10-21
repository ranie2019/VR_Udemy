using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("Esse é o Script Responsavel por Conectar ao Servidor Photon.", MessageType.Info);

        LoginManager loginManager = (LoginManager)target;
        if (GUILayout.Button("Conectando Anonimamente"))
        {
            loginManager.ConnectAnonymously();
        }
    }

}
