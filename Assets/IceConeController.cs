using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceConeController : MonoBehaviour
{
    [SerializeField]
    Rigidbody coneBody;
    [SerializeField]
    TongueController tongue;


    void Start()
    {
        target = transform.rotation;
    }

    public float RotationK;
    public float ForceK;

    float lastSwipe = 0;

    Quaternion target;
    public void SwipeUpdate(float x)
    {
        lastSwipe = x;
        coneBody.rotation = coneBody.rotation * Quaternion.Euler(-Vector3.up * lastSwipe * RotationK);
    }

    public void SwipeDone()
    {
        //coneBody.AddTorque(new Vector3(0, lastSwipe, 0), ForceMode.VelocityChange);
    }

    public void LickTapped(float pos)
    {
        tongue.SetPos(pos);
		tongue.Lick();
    }
}
