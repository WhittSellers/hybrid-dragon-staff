using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class VFXManager : MonoBehaviour
{
    public List<VisualEffect> vfxList;
    public List<VFXEventAttribute> eventAttributes;

    public ExposedProperty streamerPlayEvent = "OnStreamerPlay";

    private bool isStreamerPlaying = false;
    
    void OnEnable()
    {
        VFXEvents.current.onTriggerButtonPress += OnTriggerButtonPresss;
    }

    //Change this funciton's name to be more universal so it makes sense to call it from an animation timeline
    void OnTriggerButtonPresss()
    {
        vfxList[0].SendEvent(streamerPlayEvent);
        Debug.Log("OnStreamerPlay");
    }

    void OnDisable()
    {
        VFXEvents.current.onTriggerButtonPress -= OnTriggerButtonPresss;
    }
}
