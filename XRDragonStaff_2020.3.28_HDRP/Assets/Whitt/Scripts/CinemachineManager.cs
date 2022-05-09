using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Not linked to Show Manager yet, place holder for cinemachine functionality to moved over from Show Manager

public class CinemachineManager : MonoBehaviour
{
    public CinemachineBrain ProjectionCamera;
    public List<CinemachineVirtualCamera> vCamList;

    private int sequenceTrackingNum = 0;
    private float blendSpeed = 3.0f;
    
    public void ResetVCams()
    {
        foreach(CinemachineVirtualCamera vCam in vCamList)
        {
            vCam.Priority = 0;
        }
        vCamList[0].Priority = 1;
        sequenceTrackingNum = 0;
    }

    public void BlendToNextVCam()
    {
        if(vCamList.Count > 0)
        {
            if(sequenceTrackingNum == 0)
            {
                vCamList[0].Priority = 0;
                vCamList[1].Priority = 1;
                sequenceTrackingNum++;
            }
            if(sequenceTrackingNum == 1)
            {
                vCamList[1].Priority = 0;
                vCamList[2].Priority = 1;
                sequenceTrackingNum++;
            }
            if(sequenceTrackingNum == 2)
            {
                vCamList[2].Priority = 0;
                vCamList[1].Priority = 1;
                sequenceTrackingNum++;
            }
            if(sequenceTrackingNum <= 3)
            {
                vCamList[1].Priority = 0;
                vCamList[0].Priority = 1;
            }
        }
    }
}
