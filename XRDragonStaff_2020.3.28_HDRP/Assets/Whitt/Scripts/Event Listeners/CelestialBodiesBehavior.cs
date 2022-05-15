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

    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnCelestialBodiesVFXEvent += ToggleCelestialBodies;
        PerformanceEvents.OnDragonStaffYPosChange += SwitchRotationDirection;
    }

    void OnDisable()
    {
        PerformanceEvents.OnCelestialBodiesVFXEvent -= ToggleCelestialBodies;
        PerformanceEvents.OnDragonStaffYPosChange -= SwitchRotationDirection;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
    }

    void Update()
    {
        pivotPoint.Rotate(0, Time.deltaTime * RotationSpeed, 0);
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
