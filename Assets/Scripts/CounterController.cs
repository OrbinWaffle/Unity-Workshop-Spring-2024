using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField] GameObject counterPrefab;
    [SerializeField] float panelTime = 0.1f;
    [SerializeField] float padding = 10f;
    private RectTransform panel;
    private List<CounterUnit> counterList = new List<CounterUnit>();
    private int currentCount;
    float targetCounterLength = 0f;
    float currentCounterLength = 0f;
    float counterVel = 0f;
    void Start()
    {
        panel = GetComponent<RectTransform>();
        float prefabHeight = counterPrefab.GetComponent<RectTransform>().sizeDelta.x;
        panel.sizeDelta = new Vector2(prefabHeight + padding, 0);
        GetComponent<VerticalLayoutGroup>().padding.top = (int)padding/2;
    }
    void Update()
    {
        PanelDampController();
    }
    public void ChangeValue(int newVal)
    {
        int change = newVal - currentCount;
        currentCount = newVal;
        for(int i = 0; i < Mathf.Abs(change); i++)
        {
            if(change > 0)
            {
                if(currentCount > 0)
                {
                    GameObject instance = Instantiate(counterPrefab, transform);
                    counterList.Add(instance.GetComponent<CounterUnit>());
                }
            }
            else
            {
                if(counterList.Count > 0)
                {
                    counterList[counterList.Count-1].RemoveMe();
                    counterList.RemoveAt(counterList.Count-1);
                }
            }
        }
        float prefabHeight = counterPrefab.GetComponent<RectTransform>().sizeDelta.x;
        targetCounterLength = currentCount > 0 ? (currentCount * prefabHeight) + padding : 0;
    }
    
    private void PanelDampController()
    {
        currentCounterLength = Mathf.SmoothDamp(currentCounterLength, targetCounterLength, ref counterVel, panelTime);
        panel.sizeDelta = new Vector2(panel.sizeDelta.x, currentCounterLength);
    }
}
