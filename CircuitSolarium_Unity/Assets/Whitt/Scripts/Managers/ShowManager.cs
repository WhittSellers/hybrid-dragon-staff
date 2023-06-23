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
    [Header ("Boolean State Tracking Variables")]
    public bool performanceIntro = false;
    public bool performanceRisingAction = false;
    public bool performanceClimax = false;
    public bool performanceResolution = false;

    [Header ("Animation")]
    public Animator showAnimator;
    [Header ("Lighting")]
    public LightingManager _lightingManager;

    private void Start()
    {
        showAnimator = GetComponent<Animator>();
    }

    // This should be triggered by the trigger button on the staff
    public void StartShow()
    {
        showAnimator.SetBool("MusicStart", true);
        PerformanceEvents.current.PerformanceIntro();
        PerformanceEvents.current.FireVFXEvent();
        PerformanceEvents.current.ToggleFireSoundsEvent();
        PerformanceEvents.current.ToggleMusicEvent();
    }

    // These Next methods are called in descending order at specific times during song,
    // i.e. WhirlingDrone at 00:13, DroneDrum at 00:24, etc

    public void WhirlingDrone()
    {
        PerformanceEvents.current.EmbersVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
        PerformanceEvents.current.FireVFXEvent();
    }

    public void DroneDrum()
    {
        PerformanceEvents.current.FireRingVFXEvent();
        _lightingManager.SpinRing();
    }

    public void SynthBuild()
    {
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void RisingActionTechDrop()
    {
        PerformanceEvents.current.BlendToNextCamEvent(); // Camera (1), Pulled Back
        PerformanceEvents.current.PerformanceRising();
        PerformanceEvents.current.DollyCamEvent();
        PerformanceEvents.current.FireRingVFXEvent();
        PerformanceEvents.current.SwarmVFXEvent();
        PerformanceEvents.current.DragonOrbVFXEvent();
        PerformanceEvents.current.MatrixRingVFXEvent();
    }
    public void Tamberine()
    {
        PerformanceEvents.current.DollyCamEvent();
        //PerformanceEvents.current.MatrixRingVFXEvent();
    }

    public void FullBeatDrop()
    {
        PerformanceEvents.current.DollyCamEvent();
        //PerformanceEvents.current.MatrixRingVFXEvent();
    }

    public void Vocals()
    {
        PerformanceEvents.current.DollyCamEvent();
        //PerformanceEvents.current.MatrixRingVFXEvent();
    }

    public void FullBeatDrone()
    {
        PerformanceEvents.current.BlendToNextCamEvent(); // Camera (2), Over head
        PerformanceEvents.current.OverHeadCamEvent();
        //PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.CelestialBodiesVFXEvent();
    }

    public void VocalsDeepDrop()
    {
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void EtherealDrop()
    {
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void ClimaxStart()
    {
        PerformanceEvents.current.PerformanceClimax();
        PerformanceEvents.current.BlendToNextCamEvent(); // Camera (3), In the Fire
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void ClimaxDeepDrop()
    {
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void ClimaxBuild()
    {
        //PerformanceEvents.current.FireRingVFXEvent();
    }

    public void ClimaxDrop()
    {
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void ResolutionOscillatorStart()
    {
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void OscillatorPeak()
    {
        PerformanceEvents.current.FireVFXEvent();
        PerformanceEvents.current.PerformanceResolution();
        PerformanceEvents.current.ResetVCamEvent(); // Back to Camera (0)
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void SynthPitchDown()
    {
        //PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.CelestialBodiesVFXEvent();
    }

    public void FadeOutStart()
    {
        PerformanceEvents.current.EmbersVFXEvent();
        PerformanceEvents.current.DragonOrbVFXEvent();
    }

    public void SongEnd()
    {
        PerformanceEvents.current.ResetVFXEvent();
    }
}