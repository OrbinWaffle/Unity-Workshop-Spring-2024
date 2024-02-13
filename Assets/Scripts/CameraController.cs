using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] float smoothTime = 0f;
    [SerializeField] float distance;
    [SerializeField] Transform targetObj;
    Transform curTarget;
    float curDistance;
    Quaternion curRotation;
    Quaternion orgRotation;

    public Vector2 lookVector
    {
        get;
        set;
    }

    Vector3 posVelocity;
    Vector3 rotVelocity;
    void Start()
    {
        orgRotation = transform.rotation;
        ResetTarget();
    }
    void Update()
    {
        // find position of focused object, then create target vector which is curDistance units away
        Vector3 root = curTarget.position + offset;
        Vector3 target = root + -transform.forward * curDistance;
        
        // smoothly move to target vector
        transform.position = Vector3.SmoothDamp(transform.position, target, ref posVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(transform.rotation.eulerAngles, curRotation.eulerAngles, ref rotVelocity, smoothTime));
    }
    public void SetTarget(Transform newTarget, float newDistance)
    {
        curTarget = newTarget;
        orgRotation = transform.rotation;
        curRotation = newTarget.rotation;
        curDistance = newDistance;
    }
    public void ResetTarget()
    {
        curTarget = targetObj;
        curRotation = orgRotation;
        curDistance = distance;
    }
}
