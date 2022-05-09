using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;
using Cinemachine;

// I would like to break this script up into small subscripts that do their own thing at the command of this script/animations
// This one can probably keep track of audio too since I'm not doing too much with that for this performance besides playing music and a few SFX

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

    bool fireIsPlaying = false;
    bool embersIsPlaying = false;
    bool swarmIsPlaying = false;
    bool dragonOrbIsPlaying = false;
    bool fireRingIsPlaying = false;
    bool matrixRingIsPlaying = false;
    bool celestialBodiesIsPlaying = false;

    [Header ("Audio Sources")]
    public AudioSource fireSource;
    public AudioSource musicSource;

    [Header ("Animation")]
    public Animator showAnimator;
    public bool MusicStart = false;

    [Header ("Cinemachine")]
    public CinemachineBrain ProjectionCamera;
    public List<CinemachineVirtualCamera> vCamList;

    void OnEnable()
    {
        PerformanceEvents.onMatrixTriggerEnter += PlayMatrixRing;
    }

    private void Start()
    {
        ResetSequence();
        showAnimator = GetComponent<Animator>();
    }

    // This should be triggered by the trigger button on the staff
    public void StartShow()
    {
        PlayCampfire();
        showAnimator.SetBool("MusicStart", true);
        musicSource.Play();
        MusicStart = true;
    }

    // These Next methods are called in descending order at specific times during song,
    // i.e. WhirlingDrone at 00:13, DroneDrum at 00:24, etc
    // They each call sub-methods for playing VFX and adjusting public properties, etc
    // Not sure if it would be better for them to broadcast an event like "DroneDrumEvent" and have
    // other scripts due things on "DroneDrumEvent", or have each method call out multiple more specific events,
    // like "LightsUpEvent", "DragonOrbOnEvent", "DragonOrbOffEvent", etc
    // or if I should just get references to LightingManager,VFXManager,CinemachineManager, and call specific methods(maybe with overloads?)

    public void WhirlingDrone()
    {
        PlayEmbers();
        PlayFireRing();
    }

    public void DroneDrum()
    {
        PlayFireRing();
    }

    public void SynthBuild()
    {
        PlayFireRing();
    }

    public void RisingActionTechDrop()
    {
        vCamList[0].Priority = 0;
        vCamList[1].Priority = 1;
        PlayDragonOrb();
        PlaySwarm();
        PlayFireRing();
    }
    public void Tamberine()
    {

    }

    public void FullBeatDrop()
    {

    }

    public void Vocals()
    {

    }

    public void FullBeatDrone()
    {

    }

    public void VocalsDeepDrop()
    {

    }

    public void EtherealDrop()
    {

    }

    public void ClimaxStart()
    {
        vCamList[1].Priority = 0;
        vCamList[2].Priority = 1;
        PlayCelestialBodies();
    }

    public void ClimaxDeepDrop()
    {

    }

    public void ClimaxBuild()
    {

    }

    public void ClimaxDrop()
    {
        PlayMatrixRing();
    }

    public void ResolutionOscillatorStart()
    {
        StopCelestialBodies();
    }

    public void OscillatorPeak()
    {

    }

    public void SynthPitchDown()
    {

    }

    public void FadeOutStart()
    {

    }

    public void SongEnd()
    {

    }

    // Start of Individual VFX play/stop methods

    // Campfire, vfx[0]
    public void PlayCampfire()
    {
        vfxList[0].enabled = true;

        if(fireIsPlaying == false)
        {
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
        vfxList[1].enabled = true;
        if(embersIsPlaying == false)
        {
            vfxList[1].SendEvent(EmbersPlayEvent);
            embersIsPlaying = true;
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
        vfxList[2].enabled = true;
        if(swarmIsPlaying == false)
        {
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

    //Dragon Staff Orbs, vfx[3,4]
    public void PlayDragonOrb()
    {
        vfxList[3].enabled = true;
        vfxList[4].enabled = true;

        if(dragonOrbIsPlaying == false)
        {
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
            dragonOrbIsPlaying = false;
        }
    }

    public void PlayCelestialBodies()
    {
        vfxList[7].enabled = true;
        vfxList[8].enabled = true;
        vfxList[9].enabled = true;
        vfxList[10].enabled = true;

        if(dragonOrbIsPlaying == false)
        {
            vfxList[7].SendEvent(CelestialBodiesPlayEvent);
            vfxList[8].SendEvent(CelestialBodiesPlayEvent);
            vfxList[9].SendEvent(CelestialBodiesPlayEvent);
            vfxList[10].SendEvent(CelestialBodiesPlayEvent);
            celestialBodiesIsPlaying = true;
        }
    }

    public void StopCelestialBodies()
    {
        if(dragonOrbIsPlaying == true)
        {
            vfxList[7].SendEvent(CelestialBodiesStopEvent);
            vfxList[8].SendEvent(CelestialBodiesStopEvent);
            vfxList[9].SendEvent(CelestialBodiesStopEvent);
            vfxList[10].SendEvent(CelestialBodiesStopEvent);
            celestialBodiesIsPlaying = false;
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
        yield return new WaitForSeconds(7);

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
        yield return new WaitForSeconds(7);

        vfxList[6].enabled = false;
        matrixRingIsPlaying = false;
    }

    
    // Reset all VFX and cinemachine virtual cameras
    public void ResetSequence()
    {
        foreach(VisualEffect vfx in vfxList)
        {
            vfx.enabled = false;
        }

        foreach(CinemachineVirtualCamera vCam in vCamList)
        {
            vCam.Priority = 0;
        }
        vCamList[0].Priority = 1;
    }
    void OnDisable()
    {
        PerformanceEvents.onMatrixTriggerEnter -= PlayMatrixRing;
    }
}