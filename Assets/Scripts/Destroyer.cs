using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void KillMe()
    {
        if(GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().enabled = false;
        }
        Destroy(gameObject);
    }
}
