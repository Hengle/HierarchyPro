using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class SelectWindow : EditorWindow
{
    string Label;
    private void OnEnable()
    {
        this.minSize = new Vector2(300, 300);
        //this.autoRepaintOnSceneChange = true;
    }
    string content_title;
    List<Transform> scene_transforms = new List<Transform>();
    Dictionary<string, Transform> sceneObject = new Dictionary<string, Transform>();

    //Vertical 
    Vector2 _scroll;

    //聚焦方式
    bool focus;
    private void OnGUI()
    {


        //Label = EditorWindow.mouseOverWindow ? EditorWindow.mouseOverWindow.ToString() : "无";
        sceneObject.Clear();
        UpdateSceneObject();
        focus = EditorGUILayout.ToggleLeft("是否开启聚焦跟随旋转", focus);
        _scroll = GUILayout.BeginScrollView(_scroll);
        if (scene_transforms.Count > 0)
        {
            for (int i = 0; i < scene_transforms.Count; i++)
            {

                this.AddScene(scene_transforms[i].name, scene_transforms[i]);
                CreateButton(scene_transforms[i].name + "   " + scene_transforms[i].hideFlags, i, () =>
                 {
                     EditorGUIUtility.PingObject(scene_transforms[i]);
                     int distance = scene_transforms[i].GetComponentInChildren<Renderer>() ? 5 : 10;
                     SceneView.lastActiveSceneView.LookAt(scene_transforms[i].position, focus ? scene_transforms[i].rotation : Quaternion.identity, distance);
                     //EditorUtility.FocusProjectWindow();
                     Selection.activeGameObject = scene_transforms[i].gameObject;

                 });
            }
        }

        EditorGUILayout.EndScrollView();
        this.Repaint();
    }



    /// <summary>
    /// 检测场景中的物体
    /// </summary>
    public void UpdateSceneObject()
    {
        Transform[] allObjects = Resources.FindObjectsOfTypeAll<Transform>();
        scene_transforms.Clear();
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].gameObject && allObjects[i].hideFlags == HideFlags.None && allObjects[i].parent == null)
            {
                scene_transforms.Insert(0, allObjects[i]);
            }
        }

    }

    void AddScene(string name, Transform transform)
    {
        if (sceneObject.ContainsKey(name))
        {
            sceneObject[name] = transform;
        }
        else
        {
            sceneObject.Add(name, transform);
        }
    }
    void OnHierarchyChange()
    {

    }

    void CreateButton(string name, int index, UnityEngine.Events.UnityAction unityAction = null)
    {
        //GUILayoutUtility.BeginGroup();
        //EditorGUILayout.field
        
        if (GUILayout.Button(name))
        {
            if (unityAction != null)
            {
                unityAction();
            }

        }
    }
    //private void OnInspectorUpdate()
    //{
    //    if (mouseOverWindow == this)
    //    {
    //        EditorWindow.mouseOverWindow.Focus();
    //    }

    //}

}
