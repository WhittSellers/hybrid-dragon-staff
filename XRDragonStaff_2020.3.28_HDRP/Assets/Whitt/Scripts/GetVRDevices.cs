using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVRDevices : MonoBehaviour
{
    void Update()
    {
        GetVRDeviceList();
    }

    void GetVRDeviceList()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }
}
