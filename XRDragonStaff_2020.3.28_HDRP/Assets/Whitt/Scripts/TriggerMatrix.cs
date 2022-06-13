using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMatrix : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PerformanceEvents.current.MatrixRingVFXEvent();
    }
}
