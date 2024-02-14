using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int maxScore = 10;
    [SerializeField] int minScore = 0;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ChangeScore(-1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(score < maxScore && other.CompareTag("Collectable"))
        {
            Collectable collect = other.GetComponent<Collectable>();
            collect.CollectMe();
            ChangeScore(collect.pointValue);
        }
    }
    void ChangeScore(int amount)
    {
        score += amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        if(UIManager.main != null)
        {
            UIManager.main.UpdateMaxScore(maxScore);
            UIManager.main.UpdateScore(score);
        }
    }
}
