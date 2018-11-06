using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour {

    // Use this for initialization
    StaticClass staticClass;
    public Text text;
	void Start () {
        staticClass = new StaticClass();
        staticClass.num = 10;
        text.text = PluginCreate.test_read_cfg(Application.dataPath).ToString();
    }
	//1,1,2,3,5,8,13

    public void GetLamba(int length)
    {
        int index = 1;
        while (index != length)
        {

        }
    }


	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        staticClass = null;
    }
}
