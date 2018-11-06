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
        //EditorGUILayout.TextField(name, GUI.skin.button);

        GUISkin darkskin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
        
        if (GUILayout.Button(name, "OL SelectedRow"))
        {
            if (unityAction != null)
            {
                unityAction();
            }
        }
        GUILayout.Space(40);
    }
    string search;
    Vector2 scrollVector2;
    //void OnGUI()
    //{
    //    GUILayout.BeginHorizontal("HelpBox");
    //    GUILayout.Space(30);
    //    search = EditorGUILayout.TextField("", search, "SearchTextField", GUILayout.MaxWidth(position.x / 3));
    //    GUILayout.Label("", "SearchCancelButtonEmpty");
    //    GUILayout.EndHorizontal();
    //    scrollVector2 = GUILayout.BeginScrollView(scrollVector2);


    //    GUISkin darkskin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);



    //    GUILayout.EndScrollView();


    //}

    void DrawStyleItem(GUIStyle style)
    {
        GUILayout.BeginHorizontal("box");
        GUILayout.Space(40);
        EditorGUILayout.SelectableLabel(style.name);
        GUILayout.FlexibleSpace();
        EditorGUILayout.SelectableLabel(style.name, style);
        GUILayout.Space(40);
        EditorGUILayout.SelectableLabel("", style, GUILayout.Height(40), GUILayout.Width(40));
        GUILayout.Space(50);
        if (GUILayout.Button("复制到剪贴板"))
        {
            TextEditor textEditor = new TextEditor();
            textEditor.text = style.name;
            textEditor.OnFocus();
            textEditor.Copy();
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(10);
    }
    //private void OnInspectorUpdate()
    //{
    //    if (mouseOverWindow == this)
    //    {
    //        EditorWindow.mouseOverWindow.Focus();
    //    }

    //}
    private void OnSelectionChange()
    {
    }

}
