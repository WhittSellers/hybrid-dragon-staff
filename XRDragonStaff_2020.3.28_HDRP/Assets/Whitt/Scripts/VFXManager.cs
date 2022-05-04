using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class VFXManager : MonoBehaviour
{
    public List<VisualEffect> vfxList;
    public List<VFXEventAttribute> eventAttributes;

    public ExposedProperty FirePlayEvent = "OnFirePlay";
    public ExposedProperty EmbersPlayEvent = "OnEmbersPlay";
    public ExposedProperty HelixPlayEvent = "OnHelixPlay";
    public ExposedProperty OrbPlayEvent = "OnOrbPlay";
    public ExposedProperty OrbSplitPlayEvent = "OnOrbSplitPlay";
    public ExposedProperty EightOrbPlayEvent = "OnEightOrbPlay";
    public ExposedProperty SparklerPlayEvent = "OnSparklerPlay";
    public ExposedProperty AudioFireRingPlayEvent = "OnAudioFireRingPlay";
    public ExposedProperty CelestialBodyPlayEvent = "OnCelestialBodyPlay";
    public ExposedProperty ClimaxPlayEvent = "OnClimaxPlay";
    public ExposedProperty ClimaxEndPlayEvent = "OnClimaxEndPlay";
    public ExposedProperty CoolDownPlayEvent = "OnCoolDownPlay";

    public int vfxSequenceNum = 0;

    public bool performanceIntro = false;
    public bool performanceRisingAction = false;
    public bool performanceClimax = false;
    public bool performanceResolution = false;
    
    void OnEnable()
    {
        VFXEvents.current.onTriggerButtonPress += OnTriggerButtonPress;
    }

    //Change this funciton's name to be more universal so it makes sense to call it from an animation timeline
    void OnTriggerButtonPress()
    {
        if(vfxSequenceNum == 0)
        {
            vfxList[0].SendEvent(AudioFireRingPlayEvent);
            Debug.Log("TriggerEvent");
            // vfxSequenceNum++;
        }
    }

    void OnDisable()
    {
        VFXEvents.current.onTriggerButtonPress -= OnTriggerButtonPress;
    }
}
