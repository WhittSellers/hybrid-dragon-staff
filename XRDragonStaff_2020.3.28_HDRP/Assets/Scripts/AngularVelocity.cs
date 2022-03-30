using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AngularVelocity : MonoBehaviour
{
    public Vector3 angularVelocity;
    public Transform parentObject;

    private VisualEffect visualEffect;


    //Quaternion vfxRotation;
    Quaternion itemRotation;
    Quaternion previousRotation;
    
    private void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
        Debug.Log(visualEffect);
    }
    
    private void Start()
    {
        previousRotation = parentObject.rotation;
    }
    
    private void FixedUpdate()
    {
        Quaternion deltaRotation = parentObject.rotation * Quaternion.Inverse(previousRotation);
        
        previousRotation = parentObject.rotation;
        
        deltaRotation.ToAngleAxis(out var angle, out var axis);
        
        angle *= Mathf.Deg2Rad;
        
        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;

        visualEffect.SetVector3("Angular Velocity", angularVelocity);

        // var deltaRot = transform.rotation * Quaternion.Inverse(previousRotation);
        // var eulerRot = new Vector3( Mathf.DeltaAngle( 0, deltaRot.eulerAngles.x ), Mathf.DeltaAngle( 0, deltaRot.eulerAngles.y ),Mathf.DeltaAngle( 0, deltaRot.eulerAngles.z ) );
     
        // angularVelocity = eulerRot / Time.fixedDeltaTime;

    }
}
