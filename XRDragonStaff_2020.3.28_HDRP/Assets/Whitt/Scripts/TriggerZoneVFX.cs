using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class TriggerZoneVFX : MonoBehaviour
{
    public VisualEffect audioRingPulse;
    private void OnTriggerEnter(Collider other)
    {
        audioRingPulse.Play();
    }
}
