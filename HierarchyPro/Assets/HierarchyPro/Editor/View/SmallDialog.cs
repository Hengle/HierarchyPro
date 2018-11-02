using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class SmallDialog : BaseWindow
{
    public override void Start()
    {
        DialogStack.Push_dir.Clear();
        DialogStack.Stack.Clear();
        this.windowName = "SmallDialog";
    }
    EWindowView eWindowView = EWindowView.MainWindow;

    List<string> windowList = new List<string>();

    private void OnGUI()
    {
        eWindowView = (EWindowView)EditorGUILayout.EnumPopup(eWindowView, GUILayout.Width(200));

        if (GUILayout.Button("打开" + eWindowView.ToString()))
        {
            try
            {
                DialogStack.Push(eWindowView);
            }
            catch (System.Exception e)
            {
                Error_Log(e.Message+"    "+e.Source);
            }
            
        }
        if (DialogStack.GetStackList() != null)
        {
            GUILayout.BeginScrollView(Vector2.one, false, true);
            windowList = DialogStack.GetStackList();

            if (windowList.Count != 0)
            {
                for (int i = 0; i < windowList.Count; i++)
                {
                    windowList[i] = GUILayout.TextField(DialogStack.GetStackList()[i]);
                }
            }
            GUILayout.EndScrollView();
        }

        this.Repaint();
    }
}
