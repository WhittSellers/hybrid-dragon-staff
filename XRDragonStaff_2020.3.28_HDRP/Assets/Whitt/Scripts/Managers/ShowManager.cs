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
        PerformanceEvents.current.PerformanceRising();
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.EmbersVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void DroneDrum()
    {
        
        PerformanceEvents.current.MatrixRingVFXEvent();
        PerformanceEvents.current.FireRingVFXEvent();
        _lightingManager.SpotLightBounce();
    }

    public void SynthBuild()
    {
        PerformanceEvents.current.PerformanceClimax();
        PerformanceEvents.current.FireRingVFXEvent();
    }

    public void RisingActionTechDrop()
    {
        PerformanceEvents.current.PerformanceRising();
        PerformanceEvents.current.BlendToNextCamEvent();
        PerformanceEvents.current.FireRingVFXEvent();
        PerformanceEvents.current.SwarmVFXEvent();
        PerformanceEvents.current.DragonOrbVFXEvent();
        PerformanceEvents.current.MatrixRingVFXEvent();
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
        PerformanceEvents.current.PerformanceClimax();
        PerformanceEvents.current.BlendToNextCamEvent();
        PerformanceEvents.current.CelestialBodiesVFXEvent();
    }

    public void ClimaxDeepDrop()
    {

    }

    public void ClimaxBuild()
    {

    }

    public void ClimaxDrop()
    {
        PerformanceEvents.current.MatrixRingVFXEvent();
    }

    public void ResolutionOscillatorStart()
    {
        PerformanceEvents.current.PerformanceResolution();
        PerformanceEvents.current.BlendToNextCamEvent();
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
        PerformanceEvents.current.ResetVFXEvent();
        PerformanceEvents.current.ResetVCamEvent();
    }
}