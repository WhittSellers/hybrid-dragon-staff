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
    //ExposedProperty CelestialBodiesPlayEvent = "OnCelestialBodiesPlay";

    // Fire VFX Stop Events
    ExposedProperty FireStopEvent = "OnFireStop";
    ExposedProperty EmbersStopEvent = "OnEmbersStop";
    ExposedProperty SwarmStopEvent = "OnSwarmStop";
    ExposedProperty DragonOrbStopEvent = "OnDragonOrbStop";
    ExposedProperty FireRingStopEvent = "OnFireRingStop";
    ExposedProperty MatrixRingStopEvent = "OnMatrixRingStop";
    //ExposedProperty CelestialBodiesStopEvent = "OnCelestialBodiesStop";

    [Header ("Boolean State Tracking Variables")]
    public bool performanceIntro = false;
    public bool performanceRisingAction = false;
    public bool performanceClimax = false;
    public bool performanceResolution = false;

    public bool fireIsPlaying = false;
    public bool embersIsPlaying = false;
    public bool swarmIsPlaying = false;
    public bool dragonOrbIsPlaying = false;
    public bool fireRingIsPlaying = false;
    public bool matrixRingIsPlaying = false;
    //public bool celestialBodiesIsPlaying = false;

    public int vfxSequenceNum = 0;

    [Header ("Audio Sources")]
    public AudioSource fireSource;
    public AudioSource musicSource;

    [Header ("Animation")]
    public Animator showAnimator;
    public bool MusicStart = false;

    void OnEnable()
    {
        VFXEvents.onMatrixTriggerEnter += PlayMatrixRing;
    }

    private void Start()
    {
        ResetEffects();
        showAnimator = GetComponent<Animator>();
    }
    
    public void ResetEffects()
    {
        foreach(VisualEffect vfx in vfxList)
        {
            vfx.enabled = false;
        }
    }

    // This should be triggered by the trigger button on the staff
    public void StartShow()
    {
        showAnimator.SetBool("MusicStart", true);
        musicSource.Play();
        MusicStart = true;
    }

    // Campfire, vfx[0]
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

    // Embers, vfx[1]
    public void PlayEmbers()
    {
        if(embersIsPlaying == false)
        {
            vfxList[1].enabled = true;
            vfxList[1].SendEvent(EmbersPlayEvent);
            embersIsPlaying = true;

            PlayFireRing();
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

    // Swarm, vfx[2]
    public void PlaySwarm()
    {
        if(swarmIsPlaying == false)
        {
            vfxList[2].enabled = true;
            vfxList[2].SendEvent(SwarmPlayEvent);
            swarmIsPlaying = true;
        }
    }

    public void StopSwarm()
    {
        if(swarmIsPlaying == true)
        {
            vfxList[2].SendEvent(SwarmStopEvent);
            swarmIsPlaying = false;
        }
    }

    //Dragon Staff Orbs
    public void PlayDragonOrb()
    {
        if(dragonOrbIsPlaying == false)
        {
            vfxList[3].enabled = true;
            vfxList[4].enabled = true;
            vfxList[3].SendEvent(DragonOrbPlayEvent);
            vfxList[4].SendEvent(DragonOrbPlayEvent);
            dragonOrbIsPlaying = true;
        }
    }

    public void StopDragonOrb()
    {
        if(dragonOrbIsPlaying == true)
        {
            vfxList[3].SendEvent(DragonOrbStopEvent);
            vfxList[4].SendEvent(DragonOrbStopEvent);
            vfxList[3].enabled = false;
            vfxList[4].enabled = false;
            dragonOrbIsPlaying = false;
        }
    }
    
    // Fire Ring, vfx[5]
    public void PlayFireRing()
    {
        if(fireRingIsPlaying == false)
        {
            StartCoroutine(FireRingBlast());
        }
    }

    IEnumerator FireRingBlast()
    {
        vfxList[5].enabled = true;
        fireRingIsPlaying = true;
        yield return new WaitForSeconds(6);

        vfxList[5].enabled = false;
        fireRingIsPlaying = false;
    }

// Matrix Ring, vfx[6]
    public void PlayMatrixRing()
    {
        if(matrixRingIsPlaying == false)
        {
            StartCoroutine(MatrixRingBlast());
        }
    }

    IEnumerator MatrixRingBlast()
    {
        vfxList[6].enabled = true;
        //vfxList[6].SendEvent(MatrixRingPlayEvent);
        matrixRingIsPlaying = true;
        yield return new WaitForSeconds(6);

        vfxList[6].enabled = false;
        matrixRingIsPlaying = false;
    }

    void OnDisable()
    {
        VFXEvents.onMatrixTriggerEnter -= PlayMatrixRing;
    }
}
