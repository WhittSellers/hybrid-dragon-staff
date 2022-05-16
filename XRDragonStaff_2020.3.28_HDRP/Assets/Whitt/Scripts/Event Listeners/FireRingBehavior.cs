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
    private Vector3 _spawnPos;
    private Transform _effectPos;

    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnFireRingVFXEvent += FireRingBurst;
        PerformanceEvents.OnPerformanceIntro += SetIntroHeight;
        PerformanceEvents.OnPerformanceClimax += SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution += SetResolutionHeight;
    }

    void OnDisable()
    {
        PerformanceEvents.OnFireRingVFXEvent -= FireRingBurst;
        PerformanceEvents.OnPerformanceIntro -= SetIntroHeight;
        PerformanceEvents.OnPerformanceClimax -= SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution -= SetResolutionHeight;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _effectPos = GetComponent<Transform>();
    }
    
    void FireRingBurst()
    {
        if(isPlaying == false)
        {
            StartCoroutine(FireRingBlast());
        }
    }

    void SetIntroHeight()
    {
        _spawnPos = new Vector3(0,0,0);
        _effectPos.position = _spawnPos;
    }

    void SetClimaxHeight()
    {
        _spawnPos = new Vector3(0,2,0);
        _effectPos.position = _spawnPos;   
    }

    void SetResolutionHeight()
    {
        _spawnPos = new Vector3(0,0,0);
        _effectPos.position = _spawnPos;
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
