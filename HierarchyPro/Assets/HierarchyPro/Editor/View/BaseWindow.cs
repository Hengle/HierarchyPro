using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : UnityEditor.EditorWindow, IOpenHandler
{

    protected string windowName;

    public string GetName
    {
        get
        {
            if (windowName == null)
            {
                windowName = this.name;
            }
            return windowName;
        }
    }

    public void Error_Log(string content)
    {
        Debug.LogError(content);
    }

    public void print(string content)
    {
        Debug.Log(content);
    }

    public virtual void Start()
    {

    }

    private void OnDestroy()
    {
        CLOSE();
    }

    public void CLOSE()
    {

        DialogStack.Pop();

    }
}
