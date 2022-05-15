using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class MatrixRingBehavior : MonoBehaviour
{
    private bool isPlaying = false;
    public bool burst = true;
    private VisualEffect _vfx;
    private ExposedProperty PlayEvent = "OnPlay";
    private ExposedProperty StopEvent = "OnStop";
    private int _narrativeArcSequence = 0;
    public List<string> vfxPropertyNames;
    public DragonStaffObjectProperties _dragonStaffProps;
    public Vector3 _forceDirection;
    private Vector3 _angularVelocity;
    private GameObject _dragonStaff;

    // Start is called before the first frame update
    void OnEnable()
    {
        PerformanceEvents.OnMatrixRingVFXEvent += MatrixRingPlay;
        PerformanceEvents.OnPerformanceIntro += SetIntroSettings;
        PerformanceEvents.OnPerformanceRising += SetRisingActionSettings;
        PerformanceEvents.OnPerformanceClimax += SetClimaxSettings;
        PerformanceEvents.OnPerformanceResolution += SetResolutionSettings;
        PerformanceEvents.OnOverHeadCamEvent += AdjustForceDirection;
        PerformanceEvents.OnResetVFXEvent += ResetExposedProperties;
    }

    void OnDisable()
    {
        PerformanceEvents.OnMatrixRingVFXEvent -= MatrixRingPlay;
        PerformanceEvents.OnPerformanceRising -= SetIntroSettings;
        PerformanceEvents.OnPerformanceRising -= SetRisingActionSettings;
        PerformanceEvents.OnPerformanceClimax -= SetClimaxSettings;
        PerformanceEvents.OnPerformanceResolution -= SetResolutionSettings;
        PerformanceEvents.OnOverHeadCamEvent -= AdjustForceDirection;
        PerformanceEvents.OnResetVFXEvent -= ResetExposedProperties;
    }

    void Start()
    {
        _vfx = GetComponent<VisualEffect>();
        _dragonStaff = GameObject.Find("DragonStaffTracker");
        
        if(_dragonStaff != null)
        {
            _dragonStaffProps = _dragonStaff.GetComponent<DragonStaffObjectProperties>();
            _angularVelocity = _dragonStaffProps.angularVelocity;
        }
    }

    void SetIntroSettings()
    {
        burst = true;
        _forceDirection = new Vector3(0,0,0);
        if(vfxPropertyNames != null)
        {
            _vfx.SetVector3(vfxPropertyNames[1], _forceDirection);
            _vfx.SetFloat(vfxPropertyNames[2], 100);
        }
    }
    
    void SetRisingActionSettings()
    {
        burst = true;
        _forceDirection = new Vector3(0,-1,0);
        if(vfxPropertyNames != null)
        {
            _vfx.SetVector3(vfxPropertyNames[1], _forceDirection);
        }
    }

    void AdjustForceDirection() // This is quick fix, should figure out a better way to trigger this 
    {
        burst = false;
        _forceDirection = new Vector3(0,0,-1);
        if(vfxPropertyNames != null)
        {
            _vfx.SetVector3(vfxPropertyNames[1], _forceDirection);
        }
    }

    void SetClimaxSettings()
    {
        burst = false;
        _forceDirection = new Vector3(0,0,-10);
        if(vfxPropertyNames != null)
        {
            _vfx.SetVector3(vfxPropertyNames[0], _angularVelocity);
            _vfx.SetVector3(vfxPropertyNames[1], _forceDirection);
            _vfx.SetFloat(vfxPropertyNames[2], 1);
        }
    }

    void SetResolutionSettings()
    {
        if(vfxPropertyNames != null)
        {
            _vfx.SetVector3(vfxPropertyNames[0], _angularVelocity);
        }
    }

    void ResetExposedProperties()
    {
        _vfx.SetVector3(vfxPropertyNames[0], new Vector3(0,0,0));
        _vfx.SetVector3(vfxPropertyNames[1], new Vector3(0,0,0));
        _vfx.SetFloat(vfxPropertyNames[2], 100);
    }
    
    void MatrixRingPlay()
    {
        if(burst)
        {
            if(isPlaying == false)
            {
                StartCoroutine(MatrixRingBlast());
            }
        }
        else if (!burst)
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


    IEnumerator MatrixRingBlast()
    {
        _vfx.enabled = true;
        isPlaying = true;
        yield return new WaitForSeconds(1);
        _vfx.SendEvent(StopEvent);
        yield return new WaitForSeconds(7);
        _vfx.enabled = false;
        isPlaying = false;
    }
}
