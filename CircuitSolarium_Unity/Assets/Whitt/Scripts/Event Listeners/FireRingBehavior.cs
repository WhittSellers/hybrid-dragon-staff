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
    private bool fireGradient = true;
    private bool rainbowGradient = false;
    private VFXManager _vfxManager;
    public List<string> vfxPropertyNames;

    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnFireRingVFXEvent += FireRingBurst;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
        PerformanceEvents.OnPerformanceIntro += SetIntroHeight;
        PerformanceEvents.OnPerformanceClimax += SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution += SetResolutionHeight;
    }

    void OnDisable()
    {
        PerformanceEvents.OnFireRingVFXEvent -= FireRingBurst;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
        PerformanceEvents.OnPerformanceIntro -= SetIntroHeight;
        PerformanceEvents.OnPerformanceClimax -= SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution -= SetResolutionHeight;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _effectPos = GetComponent<Transform>();
        _vfxManager = FindObjectOfType<VFXManager>();
    }
    
    void FireRingBurst()
    {
        if(isPlaying == false)
        {
            StartCoroutine(FireRingBlast());
        }
    }

    void SetChiRollGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[2]);
                fireGradient = true;
                rainbowGradient = false;
            }
            if(fireGradient == true)
            {
                return;
            }
        }    
    }

    void SetHorizontalIsolationGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[2]);
                fireGradient = true;
                rainbowGradient = false;
            }
            if(fireGradient == true)
            {
                return;
            }
        } 
    }
    
    void SetHorizontalSpinGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(fireGradient == true)
            {
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[1]);
                fireGradient = false;
                rainbowGradient = true;
            }
            if(rainbowGradient == true)
            {
                return;
            }
        } 
    }

    void SetVerticalSpinGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(fireGradient == true)
            {
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[1]);
                fireGradient = false;
                rainbowGradient = true;
            }
            if(rainbowGradient == true)
            {
                return;
            }
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
