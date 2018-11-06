using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
[CustomEditor(typeof(Opera),true)]
public class CreateButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //Debug.Log("======>>>");
        if (GUILayout.Button("opppp"))
        {
            Opera op = (Opera)serializedObject.targetObject;

            if (op != null)
            {
                op.OperaArray();
            }
        }
    }
}
