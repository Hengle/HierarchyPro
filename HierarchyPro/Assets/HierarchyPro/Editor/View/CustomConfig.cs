using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomConfig : ScriptableObject
{
    List<ConfigInfo> config = new List<ConfigInfo>();
    
    private void Awake()
    {
        
    }
    


    
}

[SerializeField]
public class ConfigInfo
{
    public string name;
    public Rect rect;

}
