using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceEvents : MonoBehaviour
{
    public static PerformanceEvents current;

    private void Awake()
    {
        current = this;
    }
    
    // Narrative Acts
    public static event Action OnPerformanceIntro;
    public void PerformanceIntro()
    {
        if(OnPerformanceIntro != null)
        {
            OnPerformanceIntro();
        }
    }

    public static event Action OnPerformanceRising;
    public void PerformanceRising()
    {
        if(OnPerformanceRising != null)
        {
            OnPerformanceRising();
        }
    }

    public static event Action OnPerformanceClimax;
    public void PerformanceClimax()
    {
        if(OnPerformanceClimax != null)
        {
            OnPerformanceClimax();
        }
    }
    public static event Action OnPerformanceResolution;
    public void PerformanceResolution()
    {
        if(OnPerformanceResolution != null)
        {
            OnPerformanceResolution();
        }
    }

    // VFX Events

    public static event Action OnFireVFXEvent;
    public void FireVFXEvent()
    {
        if (OnFireVFXEvent != null)
        {
            OnFireVFXEvent();
        }
    }
    
    public static event Action OnEmbersVFXEvent;
    public void EmbersVFXEvent()
    {
        if (OnEmbersVFXEvent != null)
        {
            OnEmbersVFXEvent();
        }
    }

    public static event Action OnSwarmVFXEvent;
    public void SwarmVFXEvent()
    {
        if (OnSwarmVFXEvent != null)
        {
            OnSwarmVFXEvent();
        }
    }

    public static event Action OnFireRingVFXEvent;
    public void FireRingVFXEvent()
    {
        if (OnFireRingVFXEvent != null)
        {
            OnFireRingVFXEvent();
        }
    }

    public static event Action OnMatrixRingVFXEvent;
    public void MatrixRingVFXEvent()
    {
        if (OnMatrixRingVFXEvent != null)
        {
            OnMatrixRingVFXEvent();
        }
    }

    public static event Action OnCelestialBodiesVFXEvent;
    public void CelestialBodiesVFXEvent()
    {
        if (OnCelestialBodiesVFXEvent != null)
        {
            OnCelestialBodiesVFXEvent();
        }
    }

    public static event Action OnDragonOrbVFXEvent;
    public void DragonOrbVFXEvent()
    {
        if (OnDragonOrbVFXEvent != null)
        {
            OnDragonOrbVFXEvent();
        }
    }

    public static event Action OnResetVFXEvent;
    public void ResetVFXEvent()
    {
        if (OnResetVFXEvent != null)
        {
            OnResetVFXEvent();
        }
    }

    // Cinemachine Events

    public static event Action OnBlendToNextCamEvent;
    public void BlendToNextCamEvent()
    {
        if (OnBlendToNextCamEvent != null)
        {
            OnBlendToNextCamEvent();
        }
    }

    public static event Action OnResetVCamEvent;
    public void ResetVCamEvent()
    {
        if (OnResetVCamEvent != null)
        {
            OnResetVCamEvent();
        }
    }

    public static event Action OnOverHeadCamEvent;
    public void OverHeadCamEvent()
    {
        if (OnOverHeadCamEvent != null)
        {
            OnOverHeadCamEvent();
        }
    }

    // Lighting Events

    public static event Action OnToggleLightsEvent;
    public void ToggleLightsEvent()
    {
        if (OnToggleLightsEvent != null)
        {
            OnToggleLightsEvent();
        }
    }

    public static event Action OnSetSpotLightAngleEvent;
    public void SetSpotLightAngleEvent()
    {
        if (OnSetSpotLightAngleEvent != null)
        {
            OnSetSpotLightAngleEvent();
        }
    }

    public static event Action OnStrobeLightsEvent;
    public void StrobeLightsEvent()
    {
        if (OnStrobeLightsEvent != null)
        {
            OnStrobeLightsEvent();
        }
    }

    public static event Action OnAdjustLightIntensity;
    public void AdjustLightIntensity()
    {
        if(OnAdjustLightIntensity != null)
        {
            OnAdjustLightIntensity();
        }
    }

    // Audio Events

    public static event Action OnToggleFireSoundsEvent;
    public void ToggleFireSoundsEvent()
    {
        if (OnToggleFireSoundsEvent != null)
        {
            OnToggleFireSoundsEvent();
        }
    }

    public static event Action OnToggleMusicEvent;
    public void ToggleMusicEvent()
    {
        if (OnToggleMusicEvent != null)
        {
            OnToggleMusicEvent();
        }
    }

    // Dragon Staff Events
    public static event Action onTriggerButtonPress;
    public void TriggerButtonPress()
    {
        if (onTriggerButtonPress != null)
        {
            onTriggerButtonPress();
        }
    }
    public static event Action OnDragonStaffXPosChange;
    public void DragonStaffXPosChange()
    {
        if (OnDragonStaffXPosChange != null)
        {
            OnDragonStaffXPosChange();
        }
    }

    public static event Action OnDragonStaffYPosChange;
    public void DragonStaffYPosChange()
    {
        if (OnDragonStaffYPosChange != null)
        {
            OnDragonStaffYPosChange();
        }
    }

    public static event Action OnDragonStaffZPosChange;
    public void DragonStaffZPosChange()
    {
        if (OnDragonStaffZPosChange != null)
        {
            OnDragonStaffZPosChange();
        }
    }
}
