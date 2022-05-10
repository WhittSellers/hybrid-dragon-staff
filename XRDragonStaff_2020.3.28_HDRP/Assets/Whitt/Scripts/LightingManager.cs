using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    // Script to control Spot Light ring and directional light

    public Transform spotLightRing;
    private List<Transform> _spotLightPivots;
    private List<Transform> _spotLightObjects;
    private List<Light> _spotLights;
    private int lightRingNum = 8;

    public float lightIntensity;
    public float lightConeAngle;
    public float ringSpinSpeed;
    public float lightMoveSpeed;


    void Start()
    {
        for(int i = 0; i < lightRingNum; i++)
        {
            _spotLightPivots.Add(spotLightRing.GetChild(i));
            _spotLightObjects.Add(_spotLightPivots[i].GetChild(0));
        }
        for(int i = 0; i < lightRingNum; i++)
        {
            _spotLights.Add(_spotLightObjects[i].GetComponent<Light>());
        }
    }

    void SpinRing()
    {
        spotLightRing.Rotate(0, Time.deltaTime * ringSpinSpeed, 0);
    }
    
    void SpotLightBounce()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            _lightT.Rotate(MathUtils.Oscillate(0, 0, 90) * ringSpinSpeed, 0, 0);
        }
    }

    void SpotLightCenterStage()
    {

    }

    void SpotLightPivotOscilate()
    {
        foreach(Transform _lightT in _spotLightPivots)
        {
            _lightT.Rotate(0, MathUtils.Oscillate(0, 0, 360) * ringSpinSpeed, 0);
        }
    }

    void SpotLightRingAimUp()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            _lightT.Rotate(10, 0, 0);
        }
    }

    void SpotLightRingAimDown()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            _lightT.Rotate(90, 0, 0);
        }
    }
    
    IEnumerator SpotLightStrobe()
    {
        lightIntensity = MathUtils.Oscillate(0, 1000, 4000);

        foreach(Light _light in _spotLights)
        {
            _light.intensity = lightIntensity;
        }
        yield return new WaitForSeconds(5);
        lightIntensity = 3000;
    }

}
