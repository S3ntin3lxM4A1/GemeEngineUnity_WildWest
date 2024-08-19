using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerMove plRef;

    [Header("- - - - - - Main Menu - - - - - -")]
    [Header("- - - - - - Play Scene - - - - - -")]
    [Space(5)]
    [Header("- - Before Play - -")]
    public GameObject background;
    public TMP_Text numText;
    public float currentTime;
    public float setTime;
    [Space(5)]
    [Header("- - In Level - -")]
    public GameObject levelBackground;
    public TMP_Text Score;
    public int currentScore;
    public TMP_Text highScore;
    public int currentHighScore;
    public TMP_Text time;
    public float CurrentTime;
    public float setRemainingTime;
    [Space(5)]
    [Header("- - Time Over - -")]
    public GameObject overBackground;
    public TMP_Text overScoreText;
    public TMP_Text overHighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = setTime;
        CurrentTime = setRemainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        SetHighScore();
        if (currentTime >= 0)
        {
            plRef.MoveNoPLayer();
            levelBackground.SetActive(false);
            background.SetActive(true);
            overBackground.SetActive(false);
            TimeBeforePlay();
        }
        else if (CurrentTime >= 0)
        {
            plRef.MovePlayer();
            levelBackground.SetActive(true);
            TimeInPlay();
            background.SetActive(false);
            overBackground.SetActive(false);
        }
        else if (CurrentTime <= 0)
        {
            plRef.MoveNoPLayer();
            plRef.MoveStop();
            levelBackground.SetActive(false);
            background.SetActive(false);
            TimeOverMenu();
            overBackground.SetActive(true);
        }
               
    }
    public void SetText()
    {
        Score.text = currentScore.ToString();
        numText.text = currentTime.ToString("F1");
        time.text = CurrentTime.ToString("F1");
    }
    public void SetHighScore()
    {
        if (currentScore >= currentHighScore)
        {
            currentHighScore = currentScore;
            highScore.text = currentHighScore.ToString();
        }
    }
    public void SetSCore(int temp)
    {
        currentScore += temp;
    }
    public void TimeBeforePlay()
    {
        currentTime -= Time.deltaTime;
    }
    public void TimeInPlay()
    {
        CurrentTime -= Time.deltaTime;
    }
    public void TimeOverMenu()
    {
        overScoreText.text = Score.text;
        overHighScoreText.text= highScore.text;
        overBackground.SetActive(true);
    }
    public void RetryButton()
    {
        currentScore = 0;
        currentTime = setTime;
        CurrentTime = setRemainingTime;
    }
    public void MenuButton()
    {

    }
}
