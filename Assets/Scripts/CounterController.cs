using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] GameObject counterPrefab;
    private List<CounterUnit> counterList = new List<CounterUnit>();
    private int currentCount;
    public void ChangeValue(int num)
    {
        for(int i = 0; i < Mathf.Abs(num); i++)
        {
            if(num > 0)
            {
                GameObject instance = Instantiate(counterPrefab, transform);
                counterList.Add(instance.GetComponent<CounterUnit>());
                currentCount ++;
            }
            else
            {
                if(counterList.Count > 0)
                {
                    counterList[counterList.Count-1].RemoveMe();
                    counterList.RemoveAt(counterList.Count-1);
                    currentCount --;
                }
            }
        }
    }
}
