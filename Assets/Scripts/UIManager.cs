using System.Collections;
using System.Collections.Generic;
using TMPro; // ADDED
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] float fillDampTime = 0.1f;
    [SerializeField] private int score;
    [SerializeField] private int maxScore = 10;
    [SerializeField] public static UIManager main;
    [SerializeField] private TextMeshProUGUI scoreText; // ADDED
    [SerializeField] private Image fillBar;
    [SerializeField] private Image fillCircle;
    [SerializeField] private GameObject pauseMenu;

    float targetFill = 0;
    float currentFill = 0;
    float fillVel = 0;

    private void Awake()
    {
        main = this;
    }
    private void Update()
    {
        FillDampController();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf? 0 : 1;
        }
    }
    private void Start()
    {
        ChangeScore(0);
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        scoreText.text = "Cubes Collected: " + score + "/" + maxScore; // ADDED
        targetFill = (float)score / maxScore;
    }
    private void FillDampController()
    {
        currentFill = Mathf.SmoothDamp(currentFill, targetFill, ref fillVel, fillDampTime);
        fillBar.fillAmount = currentFill;
        fillCircle.fillAmount = currentFill;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneSwitcher.main.ChangeScene("Main Menu");
    }
}
