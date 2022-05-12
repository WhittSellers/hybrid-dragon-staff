using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class FireRingBehavior : MonoBehaviour
{
    private bool isPlaying = false;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnFireRingVFXEvent += FireRingBurst;
    }

    void OnDisable()
    {
        PerformanceEvents.OnFireRingVFXEvent -= FireRingBurst;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
    }
    
    void FireRingBurst()
    {
        if(isPlaying == false)
        {
            StartCoroutine(FireRingBlast());
        }
    }


    IEnumerator FireRingBlast()
    {
        _vfx.enabled = true;
        isPlaying = true;
        yield return new WaitForSeconds(7);

        _vfx.enabled = false;
        isPlaying = false;
    }
}
