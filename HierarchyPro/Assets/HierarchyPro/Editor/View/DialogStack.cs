using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class DialogStack
{
    static List<string> stack = new List<string>();


    static Dictionary<string, IOpenHandler> push_dir = new Dictionary<string, IOpenHandler>();

    public static Dictionary<string, IOpenHandler> Push_dir
    {
        get
        {
            if (push_dir == null)
            {
                push_dir = new Dictionary<string, IOpenHandler>();
            }
            string dir = "";
            foreach (var item in push_dir)
            {
                dir += item.Key + " \t";
            }
            Debug.Log(dir);
            return push_dir;
        }
    }

    public static List<string> Stack
    {
        get
        {
            if (stack == null)
            {
                stack = new List<string>();
            }
            return stack;
        }
    }


    public static List<string> GetStackList()
    {
        return Stack;
    }

    [MenuItem("Tools/Window/Main %w")]
    public static void CloseStack()
    {
        BaseWindow small = EditorWindow.GetWindow<SmallDialog>();
        small.name = small.GetName;
        small.Start();
    }

    [MenuItem("Tools/Window/Main %w")]
    public static void OpenStack()
    {
        BaseWindow small = EditorWindow.GetWindow<SmallDialog>();
        small.name = small.GetName;
        small.Start();
    }

    public static void Open(EWindowView eWindowView)
    {
        if (Push_dir.ContainsKey(eWindowView.ToString()))
        {
            return;
        }
        BaseWindow baseWindow = (BaseWindow)EditorWindow.GetWindow(Type.GetType(eWindowView.ToString()));
        baseWindow.name = baseWindow.GetName;
        baseWindow.Start();
        Push_dir.Add(baseWindow.GetName, baseWindow);
    }

    public static void Push(EWindowView eWindowView)
    {
        if (stack.Count != 0)
        {
            string dialog_name = stack.Find((string name) =>
            {
                return name == eWindowView.ToString();
            });

            if (dialog_name != null)
            {
                return;

            }
        }
        Stack.Add(eWindowView.ToString());

        Open(eWindowView);
    }

    public static void Pop()
    {
        if (Stack.Count == 0)
        {
            return;
        }

        string viewName = Stack[Stack.Count - 1];
        Stack.Remove(viewName);

        if (Push_dir.ContainsKey(viewName))
        {
            IOpenHandler view = Push_dir[viewName];
            view.CLOSE();
        }

        Push_dir.Remove(viewName);
    }


}
