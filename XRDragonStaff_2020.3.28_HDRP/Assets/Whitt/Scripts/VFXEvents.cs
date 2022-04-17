using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEvents : MonoBehaviour
{
    public static VFXEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onTriggerButtonPress;
    public void TriggerButtonPress()
    {
        if (onTriggerButtonPress != null)
        {
            onTriggerButtonPress();
        }
    }
}
