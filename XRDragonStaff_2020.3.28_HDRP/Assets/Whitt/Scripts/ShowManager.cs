using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class ShowManager : MonoBehaviour
{
    [Header ("Visual Effects")]
    public List<VisualEffect> vfxList;
    //public List<VFXEventAttribute> eventAttributes;

    // Fire VFX Play Events
    ExposedProperty FirePlayEvent = "OnFirePlay";
    ExposedProperty EmbersPlayEvent = "OnEmbersPlay";
    ExposedProperty SwarmPlayEvent = "OnSwarmPlay";
    ExposedProperty DragonOrbPlayEvent = "OnDragonOrbPlay";
    ExposedProperty FireRingPlayEvent = "OnFireRingPlay";
    ExposedProperty MatrixRingPlayEvent = "OnMatrixRingPlay";
    ExposedProperty CelestialBodiesPlayEvent = "OnCelestialBodiesPlay";

    // Fire VFX Stop Events
    ExposedProperty FireStopEvent = "OnFireStop";
    ExposedProperty EmbersStopEvent = "OnEmbersStop";
    ExposedProperty SwarmStopEvent = "OnSwarmStop";
    ExposedProperty DragonOrbStopEvent = "OnDragonOrbStop";
    ExposedProperty FireRingStopEvent = "OnFireRingStop";
    ExposedProperty MatrixRingStopEvent = "OnMatrixRingStop";
    ExposedProperty CelestialBodiesStopEvent = "OnCelestialBodiesStop";

    [Header ("Boolean State Tracking Variables")]
    public bool performanceIntro = false;
    public bool performanceRisingAction = false;
    public bool performanceClimax = false;
    public bool performanceResolution = false;

    public bool fireIsPlaying = false;
    public bool embersIsPlaying = false;
    public bool helixIsPlaying = false;
    public bool dragonOrbIsPlaying = false;
    public bool dragonOrbSplit = false;
    public bool fireRingIsPlaying = false;
    public bool matrixRingIsPlaying = false;
    public bool celestialBodiesIsPlaying = false;

    public int vfxSequenceNum = 0;

    [Header ("Audio Sources")]
    public AudioSource fireSource;
    public AudioSource musicSource;

    void OnEnable()
    {
        VFXEvents.onMatrixTriggerEnter += PlayMatrixRing;
        VFXEvents.onMatrixTriggerExit += StopMatrixRing;
    }

    private void Start()
    {
        ResetEffects();
    }
    
    public void ResetEffects()
    {
        foreach(VisualEffect vfx in vfxList)
        {
            vfx.enabled = false;
        }

    }

    public void StartShow()
    {
    }

    //Campfire
    public void PlayCampfire()
    {
            if(fireIsPlaying == false)
            {
                vfxList[0].enabled = true;
                vfxList[0].SendEvent(FirePlayEvent);
                fireSource.Play();
                fireIsPlaying = true;
            }
    }

    public void StopCampfire()
    {
            if(fireIsPlaying == true)
            {
                vfxList[0].SendEvent(FireStopEvent);
                fireSource.Stop();
                fireIsPlaying = false;
            }
    }

    //Embers
    public void PlayEmbers()
    {
            if(embersIsPlaying == false)
            {
                vfxList[1].enabled = true;
                vfxList[1].SendEvent(EmbersPlayEvent);
                embersIsPlaying = true;

                StartCoroutine(FireRingBlast());
            }
    }

    public void StopEmbers()
    {
            if(embersIsPlaying == true)
            {
                vfxList[0].SendEvent(EmbersStopEvent);
                embersIsPlaying = false;
            }
    }

    //Matrix Ring
    public void PlayMatrixRing()
    {
            if(matrixRingIsPlaying == false)
            {
                vfxList[6].SendEvent(MatrixRingPlayEvent);
                //Debug.Log("When a fire starts to burn");
                matrixRingIsPlaying = true;
            }
    }

    public void StopMatrixRing()
    {
            if(matrixRingIsPlaying == true)
            {
                vfxList[6].SendEvent(MatrixRingStopEvent);
                //Debug.Log("A fire stops burning");
                matrixRingIsPlaying = false;
            }
    }

    IEnumerator FireRingBlast()
    {
        vfxList[5].enabled = true;

        yield return new WaitForSeconds(6);

        vfxList[5].enabled = false;
    }

    void OnDisable()
    {
        VFXEvents.onMatrixTriggerEnter -= PlayMatrixRing;
        VFXEvents.onMatrixTriggerExit -= StopMatrixRing;
    }
}
