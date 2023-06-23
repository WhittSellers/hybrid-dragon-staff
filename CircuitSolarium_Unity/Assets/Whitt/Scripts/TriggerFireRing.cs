using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFireRing : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PerformanceEvents.current.FireRingVFXEvent();
    }
}
