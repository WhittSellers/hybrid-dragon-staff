using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class DragonOrbBehavior : MonoBehaviour
{
    private bool isPlaying = false;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    private bool fireGradient = true;
    private bool rainbowGradient = false;
    private VFXManager _vfxManager;
    public List<string> VFXPropertyNames;

    void OnEnable()
    {
        PerformanceEvents.OnDragonOrbVFXEvent += ToggleDragonOrb;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
    }

    void OnDisable()
    {
        PerformanceEvents.OnDragonOrbVFXEvent -= ToggleDragonOrb;
        PerformanceEvents.OnDragonStaffChiRollActive -= SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation -= SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin -= SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin -= SetVerticalSpinGradient;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _vfxManager = FindObjectOfType<VFXManager>();
    }

    void Update()
    {
        if(VFXPropertyNames.Count > 1)
        {
            _vfx.SetFloat(VFXPropertyNames[1],_vfxManager.turbulenceIntensity);
        }
    }
    
    void ToggleDragonOrb()
    {
        if(_vfx.enabled == true)
        {
            if(isPlaying == false)
            {
                _vfx.SendEvent(PlayEvent);
                isPlaying = true;
            }
            else if(isPlaying == true)
            {
                _vfx.SendEvent(StopEvent);
                isPlaying = false;
            }
        }

        if(_vfx.enabled == false)
        {
            if(isPlaying == false)
            {
                _vfx.enabled = true;
                isPlaying = true;
            }
        }
    }

    void SetChiRollGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(VFXPropertyNames[0], _vfxManager.vfxGradient[0]);
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
                _vfx.SetGradient(VFXPropertyNames[0], _vfxManager.vfxGradient[0]);
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
                _vfx.SetGradient(VFXPropertyNames[0], _vfxManager.vfxGradient[1]);
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
                _vfx.SetGradient(VFXPropertyNames[0], _vfxManager.vfxGradient[1]);
                fireGradient = false;
                rainbowGradient = true;
            }
            if(rainbowGradient == true)
            {
                return;
            }
        }
    }
}
