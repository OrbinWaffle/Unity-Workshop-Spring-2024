using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    [SerializeField] public int pointValue = 1;
    [SerializeField] GameObject particleEffect;
    public void CollectMe()
    {
        if (particleEffect != null)
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
