using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceConeController : MonoBehaviour
{
    [SerializeField]
    Rigidbody coneBody;
    [SerializeField]
    BoxCollider tongueCollider;


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
        coneBody.AddTorque(new Vector3(0, lastSwipe, 0), ForceMode.VelocityChange);
    }


    private Collider[] hitDrops = new Collider[50];
    public void LickTapped()
    {
        coneBody.AddTorque(Vector3.zero, ForceMode.VelocityChange);

        var hitCount = Physics.OverlapBoxNonAlloc(tongueCollider.center, tongueCollider.size / 2, hitDrops);

        if (hitCount > 0)
        {
            GameController.instance.score += hitCount;
        }

        for (int i = 0; i < hitCount; i++)
        {
            Destroy(hitDrops[i].gameObject);
        }
    }
}
