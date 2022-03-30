using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightLookAt : MonoBehaviour
{
    public Transform targetObject;
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
        transform.LookAt(targetObject.transform.position);
        ComparePositionValues();
    }

    void ComparePositionValues()
    {
        if(targetObject.position.y > 2.0f)
        {
            hdlight.SetColor(Color.white);
        }
        else if(targetObject.position.y <= 2.0f && targetObject.position.y >= 1.0f)
        {
            hdlight.SetColor(Color.yellow);
        }
        else if (targetObject.position.y < 1.0f)
        {
            hdlight.SetColor(Color.red);
        }
        else
        {
            hdlight.SetColor(Color.white);
        }
    }
}
