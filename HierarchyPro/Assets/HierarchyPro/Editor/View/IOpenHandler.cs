using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public interface IOpenHandler
{
    string GetName { get; }
    void Start();

    void CLOSE();
    void print(string content);
    void Error_Log(string content);
}


public enum EWindowView
{
    MainWindow = 1,
}