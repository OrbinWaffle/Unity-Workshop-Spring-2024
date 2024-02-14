using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] GameObject counterPrefab;
    private List<GameObject> counterList;
    private int currentCount;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ChangeValue(int num)
    {
        for(int i = 0; i < Mathf.Abs(num); i++)
        {
            if(num > 0)
            {
                Instantiate(counterPrefab, transform);
            }
            else
            {
                counterList.RemoveAt(0);
            }
        }
    }
}
