using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float interval = 1f;
    Light[] m_lights;
    //float nextChangeTime = 1f;
    Color prevColor = Color.white;
    Color curColor = Color.white;
    Color nextColor = Color.white;
    float curProgress;
    void Start()
    {
        m_lights = GetComponentsInChildren<Light>();
    }

    void Update()
    {
        curProgress += Time.deltaTime * (1/interval);
        curProgress = Mathf.Clamp(curProgress, 0, 1);
        curColor = new Color
        (
            Mathf.Lerp(prevColor.r, nextColor.r, curProgress),
            Mathf.Lerp(prevColor.g, nextColor.g, curProgress), 
            Mathf.Lerp(prevColor.b, nextColor.b, curProgress)
        );
        foreach (Light l in m_lights)
        {
            l.color = curColor;
        }
        if (curColor == nextColor)
        {
            prevColor = nextColor;
            nextColor = new Color
            (
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            curProgress = 0;
        }
    }
}
