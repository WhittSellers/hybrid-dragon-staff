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
    public List<VisualEffect> vfxList;

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

    bool fireIsPlaying = false;
    bool embersIsPlaying = false;
    bool swarmIsPlaying = false;
    bool dragonOrbIsPlaying = false;
    bool fireRingIsPlaying = false;
    bool matrixRingIsPlaying = false;
    bool celestialBodiesIsPlaying = false;

    void OnEnable()
    {
        PerformanceEvents.onMatrixTriggerEnter += PlayMatrixRing;
    }

    void OnDisable()
    {
        PerformanceEvents.onMatrixTriggerEnter -= PlayMatrixRing;
    }

    // Campfire, vfx[0]
    public void PlayCampfire()
    {
        vfxList[0].enabled = true;

        if(fireIsPlaying == false)
        {
            vfxList[0].SendEvent(FirePlayEvent);
            fireIsPlaying = true;
        }
    }

    public void StopCampfire()
    {
        if(fireIsPlaying == true)
        {
            vfxList[0].SendEvent(FireStopEvent);
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

    public void ResetVFX()
    {
        foreach(VisualEffect vfx in vfxList)
        {
            vfx.enabled = false;
        }
    }
}
