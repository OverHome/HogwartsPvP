using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDManager : MonoBehaviour
{
    void Start()
    {
        if (!XRSettings.isDeviceActive)
        {
            print("No headset");
        }
        else if (XRSettings.isDeviceActive &&
                 (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMDDisplay"))
        {
            print("User HMD");
        }
        else
        {
            print("Use headset" + XRSettings.loadedDeviceName);
        }
    }
}