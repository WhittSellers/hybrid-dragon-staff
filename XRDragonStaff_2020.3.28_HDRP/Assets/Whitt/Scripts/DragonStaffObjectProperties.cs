using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStaffObjectProperties : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 angularVelocity;
    public Vector3 deltaPosition;
    private Vector3 lastPostion;

    Quaternion itemRotation;
    Quaternion previousRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        previousRotation = targetObject.rotation;
        lastPostion = targetObject.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate Angular Rotation
        Quaternion deltaRotation = targetObject.rotation * Quaternion.Inverse(previousRotation);
        
        previousRotation = targetObject.rotation;
        
        deltaRotation.ToAngleAxis(out var angle, out var axis);
        
        angle *= Mathf.Deg2Rad;
        
        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;

        // var deltaRot = transform.rotation * Quaternion.Inverse(previousRotation);
        // var eulerRot = new Vector3( Mathf.DeltaAngle( 0, deltaRot.eulerAngles.x ), Mathf.DeltaAngle( 0, deltaRot.eulerAngles.y ),Mathf.DeltaAngle( 0, deltaRot.eulerAngles.z ) );
     
        // angularVelocity = eulerRot / Time.fixedDeltaTime;

        //Calculate Change in Position
        deltaPosition = targetObject.position - lastPostion;
        lastPostion = targetObject.position;
    }
}
