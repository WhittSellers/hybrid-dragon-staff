using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class MotionReactLightColor : MonoBehaviour
{
    public DragonStaffObjectProperties targetObject;
    public HDAdditionalLightData hdlight;
    private Color lightCol;
    
    // Start is called before the first frame update
    void Start()
    {
        hdlight = GetComponent<HDAdditionalLightData>();
        lightCol = hdlight.color;
    }

    // Update is called once per frame
    void Update()
    {
        lightCol.r = Mathf.Clamp(Mathf.Abs(targetObject.angularVelocity.x), 0.0f, 1.0f);
        lightCol.g = Mathf.Clamp(Mathf.Abs(targetObject.angularVelocity.y), 0.0f, 1.0f);
        lightCol.b = Mathf.Clamp(Mathf.Abs(targetObject.angularVelocity.z), 0.0f, 1.0f);
        hdlight.color = lightCol;
    }
}
