using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class Tools
{

    [MenuItem("Tools/OpenSelectWindow %q")]
    public static void AddSelecWindow()
    {
        EditorWindow.GetWindow<SelectWindow>(false, "快捷窗口", true);

    }

    public enum NONEOpen
    {
        Console,
        Hierarchy,
        Project,
        Inspector,
    }

    [MenuItem("Tools/CloseSelectWindow %F1")]
    public static void closeSelectWinwo()
    {
        Debug.Log(SceneView.lastActiveSceneView);
        string viewName = EditorWindow.focusedWindow.titleContent.text;
        try
        {
            Enum.Parse(typeof(NONEOpen), viewName);
        }
        catch (Exception e)
        {
            //SceneView.currentDrawingSceneView
            Debug.LogWarning(e.Message);
        }
        //if ((NONEOpen)Enum.Parse(typeof(NONEOpen), viewName) !=null)
        //{
        //    return;
        //}
        //EditorWindow.focusedWindow.Close();
        //Debug.Log(EditorWindow.focusedWindow.titleContent.text);
    }
}
