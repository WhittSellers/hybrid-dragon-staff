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
    public ExposedProperty DragonOrbPlayEvent = "OnDragonOrbPlay";
    public ExposedProperty SparklerPlayEvent = "OnSparklerPlay";
    public ExposedProperty FireRingPlayEvent = "OnFireRingPlay";
    public ExposedProperty MatrixRingPlayEvent = "OnMatrixRingPlay";
    public ExposedProperty CelestialBodiesPlayEvent = "OnCelestialBodiesPlay";

    public bool performanceIntro = false;
    public bool performanceRisingAction = false;
    public bool performanceClimax = false;
    public bool performanceResolution = false;

    public bool fireIsPlaying = false;
    public bool embersIsPlaying = false;
    public bool helixIsPlaying = false;
    public bool dragonOrbIsPlaying = false;
    public bool dragonOrbSplit = false;
    public bool sparklerIsPlaying = false;
    public bool fireRingIsPlaying = false;
    public bool matrixRingIsRing = false;
    public bool celestialBodiesIsPlaying = false;

    public int vfxSequenceNum = 0;

    void OnEnable()
    {
        VFXEvents.current.onTriggerButtonPress += OnTriggerButtonPress;
    }

    //Change this funciton's name to be more universal so it makes sense to call it from an animation timeline
    void OnTriggerButtonPress()
    {
        if(vfxSequenceNum == 0)
        {
            vfxList[0].SendEvent(FireRingPlayEvent);
            Debug.Log("TriggerEvent");
            // vfxSequenceNum++;
        }
    }

    void OnDisable()
    {
        VFXEvents.current.onTriggerButtonPress -= OnTriggerButtonPress;
    }
}
