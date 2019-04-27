using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
// remember to make camera follow script, as current setup will not work

public class CameraControl : MonoBehaviour {

    public Transform target; // finds and grabs the character controller to follow
    public Vector3 offset; // allows easy inspector manipulation of camera angle

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }


}
