using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=IrSh0GLo3As
public class CameraFOV : MonoBehaviour
{
    public float maxCamDistance = 10f;
    public float minCamFOV = 8f;
    public float fovSpeed = 1f;
    
    public Transform target;
    public Camera myCam;

    float initialFOV;

    // Start is called before the first frame update
    void Start()
    {
        myCam = this.GetComponent<Camera>();
        initialFOV = myCam.fieldOfView;
    }

    void ResetFOV() {
        myCam.fieldOfView = initialFOV;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            ResetFOV();
        } else {
            myCam.transform.LookAt(target); // make sure camera is looking at target
            // See if camera has moved far enough away from our target
            if (Vector3.Distance(transform.position, target.position) > maxCamDistance) {
                if (myCam.fieldOfView <= minCamFOV) {
                    myCam.fieldOfView = minCamFOV;
                } else {
                    myCam.fieldOfView -= fovSpeed;
                }
            // See if camera has moved close enough to our target
            } else if (Vector3.Distance(transform.position, target.position) < maxCamDistance) {
                myCam.fieldOfView += fovSpeed;
                if (myCam.fieldOfView >= initialFOV) {
                    ResetFOV();
                }
            }
        }
    }
}
