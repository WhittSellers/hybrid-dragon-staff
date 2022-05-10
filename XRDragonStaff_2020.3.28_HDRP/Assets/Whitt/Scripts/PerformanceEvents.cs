using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceEvents : MonoBehaviour
{
    public static PerformanceEvents current;

    private void Awake()
    {
        current = this;
    }

    public static event Action onTriggerButtonPress;
    public void TriggerButtonPress()
    {
        if (onTriggerButtonPress != null)
        {
            onTriggerButtonPress();
        }
    }

    public static event Action onMatrixTriggerEnter;
    public void MatrixTriggerEnter()
    {
        if (onMatrixTriggerEnter != null)
        {
            onMatrixTriggerEnter();
        }
    }

    public static event Action onMatrixTriggerExit;
    public void MatrixTriggerExit()
    {
        if (onMatrixTriggerExit != null)
        {
            onMatrixTriggerExit();
        }
    }
}
