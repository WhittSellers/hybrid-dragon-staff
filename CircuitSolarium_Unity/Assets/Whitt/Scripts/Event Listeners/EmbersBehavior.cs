using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class EmbersBehavior : MonoBehaviour
{
    public List<string> vfxPropertyNames;
    private bool isPlaying = false;
    private bool _centerIsOff = true;
    private bool _armAreOff = false;
    private float _attractiveDrag;
    private float _attractiveForceStrength;
    private float _particleNum;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    private bool fireGradient = true;
    private bool rainbowGradient = false;
    private VFXManager _vfxManager;
    
    
    void OnEnable()
    {
        PerformanceEvents.OnEmbersVFXEvent += ToggleEmbers;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
        PerformanceEvents.OnPerformanceIntro += SetPropertiesIntro;
        PerformanceEvents.OnPerformanceRising += SetPropertiesRising;
        PerformanceEvents.OnPerformanceClimax += SetPropertiesClimax;
        PerformanceEvents.OnPerformanceResolution += SetPropertiesResolution;
    }

    void OnDisable()
    {
        PerformanceEvents.OnEmbersVFXEvent -= ToggleEmbers;
        PerformanceEvents.OnDragonStaffChiRollActive -= SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation -= SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin -= SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin -= SetVerticalSpinGradient;
        PerformanceEvents.OnPerformanceIntro -= SetPropertiesIntro;
        PerformanceEvents.OnPerformanceRising -= SetPropertiesRising;
        PerformanceEvents.OnPerformanceClimax -= SetPropertiesClimax;
        PerformanceEvents.OnPerformanceResolution -= SetPropertiesResolution;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _vfxManager = FindObjectOfType<VFXManager>();
    }
    
    void ToggleEmbers()
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
                _vfx.SetGradient(vfxPropertyNames[5], _vfxManager.vfxGradient[0]);
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
                _vfx.SetGradient(vfxPropertyNames[5], _vfxManager.vfxGradient[0]);
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
                _vfx.SetGradient(vfxPropertyNames[5], _vfxManager.vfxGradient[1]);
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
                _vfx.SetGradient(vfxPropertyNames[5], _vfxManager.vfxGradient[1]);
                fireGradient = false;
                rainbowGradient = true;
            }
            if(rainbowGradient == true)
            {
                return;
            }
        }
    }

    void SetPropertiesIntro()
    {
        if(vfxPropertyNames.Count >= 5)
        {
            _particleNum = 500f;
            _attractiveDrag = 1.5f;
            _attractiveForceStrength = 1.5f;
            _centerIsOff = true;
            _armAreOff = false;

            _vfx.SetFloat(vfxPropertyNames[0], _particleNum);
            _vfx.SetFloat(vfxPropertyNames[1], _attractiveDrag);
            _vfx.SetFloat(vfxPropertyNames[2], _attractiveForceStrength);
            _vfx.SetBool(vfxPropertyNames[3], _centerIsOff);
            _vfx.SetBool(vfxPropertyNames[4], _armAreOff);
        }
    }

    void SetPropertiesRising()
    {
        if(vfxPropertyNames.Count >= 5)
        {
            _particleNum = 200f;
            _attractiveDrag = 1f;
            _attractiveForceStrength = 1.5f;
            _centerIsOff = false;
            _armAreOff = false;
            
            _vfx.SetFloat(vfxPropertyNames[0], _particleNum);
            _vfx.SetFloat(vfxPropertyNames[1], _attractiveDrag);
            _vfx.SetFloat(vfxPropertyNames[2], _attractiveForceStrength);
            _vfx.SetBool(vfxPropertyNames[3], _centerIsOff);
            _vfx.SetBool(vfxPropertyNames[4], _armAreOff);
        }
    }

    void SetPropertiesClimax()
    {
        if(vfxPropertyNames.Count >= 5)
        {
            _particleNum = 100f;
            _attractiveDrag = .5f;
            _attractiveForceStrength = .5f;
            _centerIsOff = false;
            _armAreOff = true;
            
            _vfx.SetFloat(vfxPropertyNames[0], _particleNum);
            _vfx.SetFloat(vfxPropertyNames[1], _attractiveDrag);
            _vfx.SetFloat(vfxPropertyNames[2], _attractiveForceStrength);
            _vfx.SetBool(vfxPropertyNames[3], _centerIsOff);
            _vfx.SetBool(vfxPropertyNames[4], _armAreOff);
        }
    }

    void SetPropertiesResolution()
    {
        if(vfxPropertyNames.Count >= 5)
        {
            _particleNum = 500f;
            _attractiveDrag = 1.5f;
            _attractiveForceStrength = 1.5f;
            _centerIsOff = true;
            _armAreOff = false;
            
            _vfx.SetFloat(vfxPropertyNames[0], _particleNum);
            _vfx.SetFloat(vfxPropertyNames[1], _attractiveDrag);
            _vfx.SetFloat(vfxPropertyNames[2], _attractiveForceStrength);
            _vfx.SetBool(vfxPropertyNames[3], _centerIsOff);
            _vfx.SetBool(vfxPropertyNames[4], _armAreOff);
        }
    }
}
