using System.Collections;
using System.Collections.Generic;
using TMPro; // ADDED
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] float fillDampTime = 0.1f;
    [SerializeField] private int score;
    [SerializeField] private int maxScore = 10;
    [SerializeField] public static UIManager main;
    [SerializeField] public GameObject cursor;
    [SerializeField] private TextMeshProUGUI scoreText; // ADDED
    [SerializeField] private TextMeshPro backpackText;
    [SerializeField] private Image backpackBar;
    [SerializeField] private Image fillBar;
    [SerializeField] private Image fillCircle;
    [SerializeField] private GameObject pauseMenu;

    float targetFill = 0f;
    float currentFill = 0f;
    float fillVel = 0f;

    float targetCursorHue = 0f;
    float currentCursorHue = 0f;
    float cursorHueVel = 0f;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        ChangeScore(0);
        Cursor.visible = false;
    }
    private void Update()
    {
        FillDampController();
        CursorHueDampController();
        cursor.transform.position = Input.mousePosition;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf? 0 : 1;
        }
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        scoreText.text = "Cubes Collected: " + score + "/" + maxScore; // ADDED
        backpackText.text = score.ToString();
        targetFill = (float)score / maxScore;
        currentCursorHue = 1;
    }
    private void FillDampController()
    {
        currentFill = Mathf.SmoothDamp(currentFill, targetFill, ref fillVel, fillDampTime);
        fillBar.fillAmount = currentFill;
        fillCircle.fillAmount = currentFill;
        backpackBar.fillAmount = currentFill;
        backpackBar.color = Color.Lerp(Color.red, Color.green, currentFill);
    }
    private void CursorHueDampController()
    {
        currentCursorHue = Mathf.SmoothDamp(currentCursorHue, targetCursorHue, ref cursorHueVel, fillDampTime);
        cursor.GetComponent<Image>().color = Color.Lerp(Color.white, Color.blue, currentCursorHue);
        cursor.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(2, 2, 2), currentCursorHue);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneSwitcher.main.ChangeScene("Main Menu");
    }
}
