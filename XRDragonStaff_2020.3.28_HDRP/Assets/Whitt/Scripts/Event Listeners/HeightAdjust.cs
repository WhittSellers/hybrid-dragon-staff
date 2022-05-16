using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightAdjust : MonoBehaviour
{
    public List<Vector3> _targetPos;
    private Transform _originTransform;
    void OnEnable()
    {
        PerformanceEvents.OnPerformanceIntro += SetIntroHeight;
        PerformanceEvents.OnPerformanceRising += SetRisingHeight;
        PerformanceEvents.OnPerformanceClimax += SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution += SetResolutionHeight;
    }

    void OnDisable()
    {
        PerformanceEvents.OnPerformanceIntro -= SetIntroHeight;
        PerformanceEvents.OnPerformanceRising -= SetRisingHeight;
        PerformanceEvents.OnPerformanceClimax -= SetClimaxHeight;
        PerformanceEvents.OnPerformanceResolution -= SetResolutionHeight;
    }

    void Start()
    {
        _originTransform = GetComponent<Transform>();
    }

    void SetIntroHeight()
    {
        _originTransform.position = _targetPos[0]; 
    }

    void SetRisingHeight()
    {
        _originTransform.position = new Vector3(
            Mathf.Lerp(_originTransform.position.x, _targetPos[1].x, 1),
            Mathf.Lerp(_originTransform.position.y, _targetPos[1].y, 1),
            Mathf.Lerp(_originTransform.position.z, _targetPos[1].z, 1));
    }

    void SetClimaxHeight()
    {
        _originTransform.position = new Vector3(
            Mathf.Lerp(_originTransform.position.x, _targetPos[2].x, 1),
            Mathf.Lerp(_originTransform.position.y, _targetPos[2].y, 1),
            Mathf.Lerp(_originTransform.position.z, _targetPos[2].z, 1));
    }

    void SetResolutionHeight()
    {
        _originTransform.position = new Vector3(
            Mathf.Lerp(_originTransform.position.x, _targetPos[3].x, 1),
            Mathf.Lerp(_originTransform.position.y, _targetPos[3].y, 1),
            Mathf.Lerp(_originTransform.position.z, _targetPos[3].z, 1));
    }
}
