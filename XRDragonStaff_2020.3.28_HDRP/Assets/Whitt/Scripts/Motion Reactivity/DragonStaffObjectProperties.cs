using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I would like for this script to broadcast when Angular Velocity values change sign (+/-) 
// and when a Delta Position value spikes above certain threshold, but haven't built that in yet.
// I would then like to create a companion script(s) that can be attached to other objects 
// that will read the transform values here and listen for the events fired from this script

public class DragonStaffObjectProperties : MonoBehaviour
{
    public Vector3 angularVelocity;
    public Vector3 deltaPosition;
    public float _threshold;
    private Vector3 lastPostion;
    private Transform _transform;

    Quaternion previousRotation;
    Quaternion deltaRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        previousRotation = _transform.rotation;
        lastPostion = _transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate Angular Rotation
        deltaRotation = _transform.rotation * Quaternion.Inverse(previousRotation);
        
        previousRotation = _transform.rotation;
        
        deltaRotation.ToAngleAxis(out var angle, out var axis);
        
        angle *= Mathf.Deg2Rad;
        
        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;

        // var deltaRot = transform.rotation * Quaternion.Inverse(previousRotation);
        // var eulerRot = new Vector3( Mathf.DeltaAngle( 0, deltaRot.eulerAngles.x ), Mathf.DeltaAngle( 0, deltaRot.eulerAngles.y ),Mathf.DeltaAngle( 0, deltaRot.eulerAngles.z ) );
     
        // angularVelocity = eulerRot / Time.fixedDeltaTime;

        //Calculate Change in Position
        deltaPosition = _transform.position - lastPostion;
        lastPostion = _transform.position;

        //SendVelocityEvents();
    }

    // This functionality has been replaced by data proccessing from TouchDesigner that sends out OSC messages when a movement
    // state is detected. 
    // void SendVelocityEvents()
    // {
    //     if(Mathf.Abs(angularVelocity.x) < Mathf.Abs(angularVelocity.y) && Mathf.Abs(angularVelocity.x) < Mathf.Abs(angularVelocity.z) && angularVelocity.x != 0f)
    //     {
    //         //Debug.Log("X Vel Change");
    //     }
    //     if(Mathf.Abs(angularVelocity.y) < Mathf.Abs(angularVelocity.x) && Mathf.Abs(angularVelocity.y) < Mathf.Abs(angularVelocity.z) && angularVelocity.y != 0f)
    //     {
    //         //Debug.Log("X Vel Change");
    //     }
    //     if(Mathf.Abs(angularVelocity.z) < Mathf.Abs(angularVelocity.x) && Mathf.Abs(angularVelocity.z) < Mathf.Abs(angularVelocity.y) && angularVelocity.z != 0f)
    //     {
    //         //Debug.Log("X Vel Change");
    //     }
    // }
}
