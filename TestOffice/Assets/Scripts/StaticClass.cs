using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass
{
    static StaticClass()
    {
        Debug.Log("静态构造调用");
    }
    public StaticClass()
    {
        Debug.Log("普通构造调用");
    }
    ~StaticClass()
    {
        Debug.Log("析构调用");
    }

    public int num;
}
