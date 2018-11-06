using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StyleCheck : MonoBehaviour
{

    public GUISkin GUISkin;

    public int index = 0;

    private void OnGUI()
    {
        GUISkin dark = UnityEditor.EditorGUIUtility.GetBuiltinSkin(UnityEditor.EditorSkin.Inspector);
        GUISkin.customStyles = dark.customStyles;

        if (index != -1)
        {
            GUILayout.Button(GUISkin.customStyles[index].name, GUISkin.customStyles[index],GUILayout.Width(300), GUILayout.Height(300));
        }

    }
}
