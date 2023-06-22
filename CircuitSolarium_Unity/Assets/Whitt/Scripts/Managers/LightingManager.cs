using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    // Script to control Spot Light ring and directional light

    // Master Game Object for Lighting Ring
    public Transform spotLightRing;
    // Transforms for empty Game Objects that should only rotate objects on the Y axis
    public List<Transform> _spotLightPivots;
    // Transform of Game Objects containing the actual Light component, should only be rotated on X Axis
    public List<Transform> _spotLightObjects;
    // Actual light components from the Spot Light Game Objects
    public List<Light> _spotLights;
    // Number of lights in the ring
    private int lightRingNum = 8;
    public Light _directionalLight;
    public float lightIntensity;
    public float lightConeAngle;
    public float ringSpinSpeed;
    public float lightMoveSpeed;
    private Quaternion curQuat;
    private Quaternion tarQuat;

    void OnEnable()
    {
        PerformanceEvents.OnSetSpotLightAngleEvent += SetSpotLightObjectAngle;
        PerformanceEvents.OnAdjustLightIntensity += SetLightIntensity;
    }
    
    void OnDisable()
    {
        PerformanceEvents.OnSetSpotLightAngleEvent -= SetSpotLightObjectAngle;
        PerformanceEvents.OnAdjustLightIntensity -= SetLightIntensity;
    }

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

    public void SpinRing()
    {
        spotLightRing.RotateAround(spotLightRing.position, Vector3.up, Time.deltaTime * ringSpinSpeed);
    }
    
    public void SetSpotLightPivotAngle()
    {
        // need to combine the functionality of the other scripts into this one that uses a bool or int to track state
        // and pick which lighting pattern to use with the desired angle
    }

    public void SetSpotLightObjectAngle()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            _lightT.rotation = Quaternion.Euler(MathUtils.Oscillate(0, 0, 90) * ringSpinSpeed, 0, 0);
        }
    }
    
    public void SpotLightBounce()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            _lightT.rotation = Quaternion.Euler(MathUtils.Oscillate(0, 0, 90) * ringSpinSpeed, 0, 0);
        }
    }

    public void SetLightIntensity()
    {

    }

    public void SpotLightPivotOscilate()
    {
        foreach(Transform _lightT in _spotLightPivots)
        {
            _lightT.rotation = Quaternion.Euler(0, MathUtils.Oscillate(0, 0, 359) * ringSpinSpeed, 0);
        }
    }

    public void SpotLightRingAimUp()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            curQuat = _lightT.rotation;
            tarQuat = new Quaternion(10, 0, 0, 0);
            _lightT.rotation = Quaternion.Lerp(_lightT.rotation, tarQuat, ringSpinSpeed * Time.deltaTime);
        }
    }

    public void SpotLightRingAimDown()
    {
        foreach(Transform _lightT in _spotLightObjects)
        {
            curQuat = _lightT.rotation;
            tarQuat = new Quaternion(90, 0, 0, 0);
            _lightT.rotation = Quaternion.Lerp(_lightT.rotation, tarQuat, ringSpinSpeed * Time.deltaTime);
        }
    }
    
    IEnumerator SpotLightStrobe()
    {
        lightIntensity = MathUtils.Oscillate(0, 10000, 40000);

        foreach(Light _light in _spotLights)
        {
            _light.intensity = lightIntensity;
            yield return new WaitForSeconds(5);
        }
        lightIntensity = 30000;
    }

}
