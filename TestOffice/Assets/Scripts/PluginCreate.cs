using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using UnityEngine;

public class PluginCreate {

    [DllImport("Dll1")]
    public static extern int test_read_cfg(string path);
}
