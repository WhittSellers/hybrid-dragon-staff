using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtils
{
    public static int Oscillate(int input, int min, int max)
    {
        int range = max - min ;
        return min + Mathf.Abs(((input + range) % (range * 2)) - range);
    }
}
