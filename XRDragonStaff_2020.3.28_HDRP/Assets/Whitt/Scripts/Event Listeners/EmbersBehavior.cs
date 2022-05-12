using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class EmbersBehavior : MonoBehaviour
{
    private bool isPlaying = false;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnEmbersVFXEvent += ToggleEmbers;
    }

    void OnDisable()
    {
        PerformanceEvents.OnEmbersVFXEvent -= ToggleEmbers;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
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
}
