using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher main;
    private void Awake()
    {
        if(main != null)
        {
            Destroy(gameObject);
        }
        else
        {
            main = this;
            DontDestroyOnLoad(this);
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
