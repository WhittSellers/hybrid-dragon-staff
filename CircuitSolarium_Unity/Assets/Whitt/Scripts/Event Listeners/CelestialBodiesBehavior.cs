using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class CelestialBodiesBehavior : MonoBehaviour
{
    private bool isPlaying = false;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";

    public Transform pivotPoint;
    public float RotationSpeed;
    public bool clockwise = false;
    public List<string> vfxPropertyNames;
    private bool fireGradient = true;
    private bool rainbowGradient = false;
    private VFXManager _vfxManager;


    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnCelestialBodiesVFXEvent += ToggleCelestialBodies;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SwitchRotationDirection;
    }

    void OnDisable()
    {
        PerformanceEvents.OnCelestialBodiesVFXEvent -= ToggleCelestialBodies;
        PerformanceEvents.OnDragonStaffChiRollActive += SetChiRollGradient;
        PerformanceEvents.OnDragonStaffHorizontalIsolation += SetHorizontalIsolationGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin += SetHorizontalSpinGradient;
        PerformanceEvents.OnDragonStaffVerticalSpin += SetVerticalSpinGradient;
        PerformanceEvents.OnDragonStaffHorizontalSpin -= SwitchRotationDirection;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _vfxManager = FindObjectOfType<VFXManager>();
    }

    void Update()
    {
        pivotPoint.Rotate(0, Time.deltaTime * RotationSpeed, 0);
    }

    void SetChiRollGradient()
    {
        if(_vfxManager.vfxGradient.Count >= 2)
        {
            if(rainbowGradient == true)
            {
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[0]);
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
                _vfx.SetGradient(vfxPropertyNames[0], _vfxManager.vfxGradient[0]);
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

    void SwitchRotationDirection()
    {
        RotationSpeed = RotationSpeed * -1;
        if(RotationSpeed > 0)
        {
            clockwise = true;
        }
        else
        {
            clockwise = false;
        }
    }
    
    void ToggleCelestialBodies()
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
}
