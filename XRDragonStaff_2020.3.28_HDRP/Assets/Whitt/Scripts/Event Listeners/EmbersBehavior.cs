using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class EmbersBehavior : MonoBehaviour
{
    public DragonStaffObjectProperties _dragonStaffProps;

    [Header ("Attractive Targets")]
    public List<Transform> forceTargetList;
    public List<string> vfxPropertyNames;
    private GameObject _xROrigin;

    private bool isPlaying = false;
    private GameObject _dragonStaff;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnEmbersVFXEvent += ToggleEmbers;
        PerformanceEvents.OnPerformanceIntro += SetAttractiveTargetsIntro;
        PerformanceEvents.OnPerformanceRising += SetAttractiveTargetsRising;
        PerformanceEvents.OnPerformanceResolution += SetAttractiveTargetsResolution;
    }

    void OnDisable()
    {
        PerformanceEvents.OnEmbersVFXEvent -= ToggleEmbers;
        PerformanceEvents.OnPerformanceIntro -= SetAttractiveTargetsIntro;
        PerformanceEvents.OnPerformanceRising -= SetAttractiveTargetsRising;
        PerformanceEvents.OnPerformanceResolution -= SetAttractiveTargetsResolution;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _dragonStaff = GameObject.Find("DragonStaffTracker");
        _xROrigin = GameObject.Find("XR Origin");
        if(_dragonStaff != null)
        {
            _dragonStaffProps = _dragonStaff.GetComponent<DragonStaffObjectProperties>();
            _vfx.SetFloat(vfxPropertyNames[2], _dragonStaffProps.angularVelocity.y);
        }
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

    void SetAttractiveTargetsIntro()
    {
        if(vfxPropertyNames.Count >= 2 && forceTargetList.Count == 3)
        {
            _vfx.SetVector3(vfxPropertyNames[0], forceTargetList[0].position + _xROrigin.transform.position);
            _vfx.SetVector3(vfxPropertyNames[1], forceTargetList[1].position + _xROrigin.transform.position);
        }
    }

    void SetAttractiveTargetsRising()
    {
        if(vfxPropertyNames.Count >= 2 && forceTargetList.Count == 3)
        {
            _vfx.SetVector3(vfxPropertyNames[0], forceTargetList[2].position);
            _vfx.SetVector3(vfxPropertyNames[1], forceTargetList[2].position);
        }
    }

    void SetAttractiveTargetsResolution()
    {
        if(vfxPropertyNames.Count >= 2 && forceTargetList.Count == 3)
        {
            _vfx.SetVector3(vfxPropertyNames[0], forceTargetList[0].position + _xROrigin.transform.position);
            _vfx.SetVector3(vfxPropertyNames[1], forceTargetList[1].position + _xROrigin.transform.position);
        }
    }
}
