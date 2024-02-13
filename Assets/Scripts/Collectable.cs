using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    [SerializeField] int pointValue = 1;
    [SerializeField] GameObject particleEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (particleEffect != null)
            {
                Instantiate(particleEffect, transform.position, transform.rotation);
            }
            UIManager.main.ChangeScore(pointValue);
            Destroy(gameObject);
        }
    }
}
