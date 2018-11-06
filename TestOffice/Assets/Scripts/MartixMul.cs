using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Opera
{
    void OperaArray();
}
public class MartixMul : MonoBehaviour, Opera
{
    public int[,] array1;
    public int[,] array2;

    public void OperaArray()
    {
        if (array1 == null||array2 == null)
        {
            return;
        }
        if (array1.GetLength(0) != array2.GetLength(0))
        {
            return;
        }

        int[,] source = new int[array2.Length, array2.Length];
        for (int i = 0; i < array2.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                source[i, j] = array1[i, j] + array2[i, j];
            }
        }

    }


    private void Reset()
    {
        
    }
}



