using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Not linked to Show Manager yet, place holder for cinemachine functionality to moved over from Show Manager

public class CinemachineManager : MonoBehaviour
{
    public CinemachineBrain ProjectionCamera;
    public List<CinemachineVirtualCamera> vCamList;
    public float _targetSpeed;
    private CinemachineDollyCart _dolly;
    public bool _dollyClockwise;

    private int sequenceTrackingNum = 0;
    private float blendSpeed = 3.0f;
    
    void OnEnable()
    {
        PerformanceEvents.OnBlendToNextCamEvent += BlendToNextVCam;
        PerformanceEvents.OnResetVCamEvent += ResetVCams;
        PerformanceEvents.OnDollyCamEvent += SetDollySpeed;
    }

    void OnDisable()
    {
        PerformanceEvents.OnBlendToNextCamEvent -= BlendToNextVCam;
        PerformanceEvents.OnResetVCamEvent -= ResetVCams;
        PerformanceEvents.OnDollyCamEvent -= SetDollySpeed;
    }

    private void Start()
    {
        ResetVCams();
        if(vCamList[1].GetComponent<CinemachineDollyCart>().enabled == true)
        {
            _dolly = vCamList[1].GetComponent<CinemachineDollyCart>();
        }
    }

    public void ResetVCams()
    {
        foreach(CinemachineVirtualCamera vCam in vCamList)
        {
            vCam.Priority = 0;
        }
        vCamList[0].Priority = 1;
        sequenceTrackingNum = 0;
    }

    public void SetDollySpeed()
    {
        if(_dollyClockwise)
        {
            _targetSpeed = Mathf.Lerp(_targetSpeed, -2f, 1);
            _dollyClockwise = false;
        }
        else if(!_dollyClockwise)
        {
            _targetSpeed = Mathf.Lerp(_targetSpeed, 2f, 1);
            _dollyClockwise = true;
        }
        
        _dolly.m_Speed = _targetSpeed;
        Debug.Log("Dolly speed is " + _dolly.m_Speed);
    }

    public void BlendToNextVCam()
    {
        if(vCamList.Count == 4)
        {
            if(sequenceTrackingNum == 0)
            {
                vCamList[0].Priority = 0;
                vCamList[1].Priority = 1;
                sequenceTrackingNum++;
            }
            else if(sequenceTrackingNum == 1)
            {
                vCamList[1].Priority = 0;
                vCamList[2].Priority = 1;
                sequenceTrackingNum++;
            }
            else if(sequenceTrackingNum == 2)
            {
                vCamList[2].Priority = 0;
                vCamList[3].Priority = 1;
                sequenceTrackingNum++;
            }
            else if(sequenceTrackingNum == 3)
            {
                vCamList[3].Priority = 0;
                vCamList[0].Priority = 1;
            }
            else if(sequenceTrackingNum >= 4)
            {
                vCamList[1].Priority = 0;
                vCamList[2].Priority = 0;
                vCamList[3].Priority = 0;
                vCamList[0].Priority = 1;
            }
        }
    }
}
