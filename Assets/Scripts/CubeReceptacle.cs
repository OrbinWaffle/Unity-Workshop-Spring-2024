using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeReceptacle : MonoBehaviour
{
    [SerializeField] UnityEvent OnAcceptCube;
    [SerializeField] bool deactivateOnTrigger = true;
    
    Animator anim;

    GameObject player;

    bool canActivate = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }    
    void OnTriggerEnter(Collider other)
    {
        if(!canActivate){return;}

        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            RemoveControlFromPlayer();
            anim.Rebind();
            anim.SetTrigger("onTouched");

            if(deactivateOnTrigger)
            {
                canActivate = false;
            }
        }
    }
    public void InvokeEvent()
    {
        OnAcceptCube.Invoke();
    }
    public void RemoveControlFromPlayer()
    {
        player.transform.parent = transform;
        player.GetComponent<PlayerController>().Freeze(true);
    }
    public void ReturnControlToPlayer()
    {
        Vector3 pos = player.transform.position;
        Quaternion rot = player.transform.rotation;
        player.transform.parent = null;
        anim.Rebind();
        player.transform.position = pos;
        player.transform.rotation = rot;
        player.GetComponent<PlayerController>().Freeze(false);
        player.GetComponent<PlayerController>().ResetPlayer();
        player = null;
    }
}
