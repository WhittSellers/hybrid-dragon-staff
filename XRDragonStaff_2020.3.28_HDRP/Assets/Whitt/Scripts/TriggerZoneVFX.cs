using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class TriggerZoneVFX : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        VFXEvents.current.MatrixTriggerEnter();
    }
}
