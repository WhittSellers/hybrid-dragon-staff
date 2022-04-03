using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDragonRingX : MonoBehaviour
{
    public DragonStaffObjectProperties targetObject;
    
    Quaternion updateRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
        updateRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateRotation.x = targetObject.angularVelocity.x;
        //updateRotation.y = targetObject.angularVelocity.y;
        //updateRotation.z = targetObject.angularVelocity.z;
        transform.rotation = updateRotation;
    }
}
