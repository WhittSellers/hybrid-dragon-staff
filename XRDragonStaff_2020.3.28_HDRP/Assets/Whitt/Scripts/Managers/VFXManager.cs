using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

// Right now this script is not enabled in game, this is just holding everything I want it to hold that I have written so far
// Still Open to the best way to call these methods
// Would like to have a way to keep better track off which effects are in which spots in the list without hard coding references if possible

// Also for the particle bursts, I would like to be able to burst them more frequently, but unless I disable and re-enable it the burst ring radius won't reset and it will be messed up

public class VFXManager : MonoBehaviour
{
    public List<Gradient> vfxGradient;
    public List<VisualEffect> vfxList;
    public int VFXNum = 9; 

    void OnEnable()
    {
        // PerformanceEvents.FireVFXEvent += PlayCampfire;
        // PerformanceEvents.EmbersVFXEvent += PlayEmbers;
        // PerformanceEvents.SwarmVFXEvent += PlaySwarm;
        // PerformanceEvents.DragonOrbVFXEvent += PlayDragonOrb;
        // PerformanceEvents.FireRingVFXEvent += PlayFireRing;
        PerformanceEvents.OnDragonStaffVerticalSpin += PlayVerticalSpin;
        PerformanceEvents.OnDragonStaffChiRollActive += PlayChiRollActive;
        PerformanceEvents.OnResetVFXEvent += ResetVFX;
    }

    void OnDisable()
    {
        // PerformanceEvents.FireVFXEvent -= PlayCampfire;
        // PerformanceEvents.EmbersVFXEvent -= PlayEmbers;
        // PerformanceEvents.SwarmVFXEvent -= PlaySwarm;
        // PerformanceEvents.DragonOrbVFXEvent -= PlayDragonOrb;
        // PerformanceEvents.FireRingVFXEvent -= PlayFireRing;
        PerformanceEvents.OnDragonStaffVerticalSpin += PlayVerticalSpin;
        PerformanceEvents.OnDragonStaffChiRollActive -= PlayChiRollActive;
        PerformanceEvents.OnResetVFXEvent -= ResetVFX;
    }

    void Start() {
        
    }

    void PlayChiRollActive()
    {

    }

    void PlayVerticalSpin()
    {

    }

    public void ResetVFX()
    {
        foreach(VisualEffect vfx in vfxList)
        {
            vfx.enabled = false;
        }
    }
}
