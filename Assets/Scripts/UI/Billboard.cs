using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Billboard : MonoBehaviour
{
    [FormerlySerializedAs("Camera")] public Transform MainCamera;
    
    void Awake()
    {
        if (MainCamera == null)
            MainCamera = UnityEngine.Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.forward = MainCamera.forward;
    }
}
