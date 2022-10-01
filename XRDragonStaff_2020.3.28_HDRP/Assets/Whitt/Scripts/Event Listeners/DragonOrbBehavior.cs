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
    public List<Gradient> vfxGradient;
    public List<string> VFXPropertyNames;
    // Start is called before the first frame update
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
        if(vfxGradient.Count > 0)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(VFXPropertyNames[0], vfxGradient[0]);
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
        if(vfxGradient.Count > 0)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(VFXPropertyNames[0], vfxGradient[0]);
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
        if(vfxGradient.Count > 0)
        {
            if(fireGradient == true)
            {
                _vfx.SetGradient(VFXPropertyNames[0], vfxGradient[1]);
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
        if(vfxGradient.Count > 0)
        {
            if(fireGradient == true)
            {
                _vfx.SetGradient(VFXPropertyNames[0], vfxGradient[1]);
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
