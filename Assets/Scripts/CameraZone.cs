using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] Transform focusPoint;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().SetTarget(focusPoint, distance);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().ResetTarget();
        }
    }
}
