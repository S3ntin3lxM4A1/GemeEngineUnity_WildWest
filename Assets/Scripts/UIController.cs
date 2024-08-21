using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerMove plRef;

    [Header("- - - - - - Main Menu - - - - - -")]
    public GameObject mainMenuPanal;
    public TMP_Text menuHighScoreText;
    [Header("- - - - - - Play Scene - - - - - -")]
    [Space(5)]
    [Header("- - Before Play - -")]
    public GameObject background;
    public TMP_Text numText;
    public float currentTime, setTime;
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
    [Space(5)]
    [Header("- - Difficulty - -")]
    public Slider difSlider;
    public TMP_Text difText;
    private float difNum;
    [Header("- - - - - - Sound - - - - - -")]
    public AudioSource musikSource;
    public AudioClip menuMusik, playMusik;

    // Start is called before the first frame update
    void Start()
    {
        musikSource.clip = menuMusik;
        musikSource.Play();
        currentTime = setTime;
        CurrentTime = setRemainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        SetHighScore();
        if (mainMenuPanal.activeSelf)
        {
            levelBackground.SetActive(false);
            background.SetActive(false);
            overBackground.SetActive(false);
        }
        else if (currentTime >= 0)
        {
            plRef.MoveNoPLayer();
            levelBackground.SetActive(false);
            background.SetActive(true);
            overBackground.SetActive(false);
            TimeBeforePlay();
        }
        else if (CurrentTime >= 0)
        {
            //musikSource.PlayOneShot();
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
        difNum = difSlider.value;
        difText.text = difNum.ToString();
    }
    public void SetText()
    {
        Score.text = currentScore.ToString();
        numText.text = currentTime.ToString("F0");
        time.text = CurrentTime.ToString("F0");
    }
    public void SetHighScore()
    {
        if (currentScore >= currentHighScore)
        {
            currentHighScore = currentScore;
            highScore.text = currentHighScore.ToString();
            menuHighScoreText.text = highScore.text;
        }
    }
    public void SetScore(int temp)
    {
        currentScore += temp;
    }
    public void TimeBeforePlay()
    {
        currentTime -= Time.deltaTime;
    }
    public void TimeInPlay()
    {
        CurrentTime -= Time.deltaTime * difNum;
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
        currentScore = 0;
        currentTime = setTime;
        CurrentTime = setRemainingTime;
        mainMenuPanal.SetActive(true);
        musikSource.clip = menuMusik;
        musikSource.Play();
    }
    public void ResetHighScore()
    {
        currentHighScore = 0;
        highScore.text = currentHighScore.ToString();
        menuHighScoreText.text = highScore.text;
    }
    public void PlusTime(float tm)
    {
        CurrentTime += tm;
    }
    public void PlayButton() { 
        musikSource.clip = playMusik;
        musikSource.Play();
    }
}
