using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterUnit : MonoBehaviour
{
    public void RemoveMe()
    {
        GetComponent<Animator>().SetTrigger("Remove");
    }
}
