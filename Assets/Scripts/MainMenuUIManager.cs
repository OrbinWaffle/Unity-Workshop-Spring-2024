using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public void GoToLevel(string levelName)
    {
        SceneSwitcher.main.ChangeScene(levelName);
    }
}
