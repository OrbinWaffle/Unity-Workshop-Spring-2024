using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public Button startButton;
    public void GoToLevel(string levelName)
    {
        SceneSwitcher.main.ChangeScene(levelName);
    }
    public void ToggleButton(bool on)
    {
        startButton.interactable = on;
    }
}
