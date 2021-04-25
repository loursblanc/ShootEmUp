using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public Text livesText; 
    public Text scoreText;
    public Text highScoreText;
    public Slider damageSlider;
    private Image _damageFillArea;
    public Color damageSliderColorMin = Color.yellow;
    public Color damageSliderColorMax = Color.red;

    [Header("NAV")]
    public Text gameStateText;
    public Button pauseButton;
    public Button resumeButton;
    public Image pauseMenu;

    [Header("Settings")]
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;

    public float MusicVolume
    {
        get { return PlayersSettings.MusicVolume; }
        set { PlayersSettings.MusicVolume = value; }
    }
    public float SFXVolume
    {
        get { return PlayersSettings.SFXVolume; }
        set { PlayersSettings.SFXVolume = value; }
    }

    private void Awake()
    {
        _damageFillArea = damageSlider.fillRect.GetComponent<Image>();
        damageSlider.maxValue = GameManager.maxDamage;

        musicVolumeSlider.value = MusicVolume;
        SFXVolumeSlider.value = SFXVolume;
    }


    private void Start()
    {
        GameManager.Lives = 1;
        OnStateChanged(GameManager.State);

        livesText.text = string.Format("{1} {0}",GameManager.Lives > 1 ? "Lives" : "Life", GameManager.Lives);
        scoreText.text = string.Format("Score : {0}", GameManager.Score);
        highScoreText.text = string.Format("High Score : {0}", GameManager.HighScore);
        damageSlider.value = GameManager.Damage;
        _damageFillArea.color = Color.Lerp(damageSliderColorMin, damageSliderColorMax, GameManager.Damage/damageSlider.maxValue);

        GameManager.ScoreChanged += delegate (int score)
            {
                scoreText.text = string.Format("Score : {0}", score);
            };

        GameManager.HighScoreChanged += delegate (int highScore)
            {
                highScoreText.text = string.Format("High Score : {0}", highScore);
            };

        GameManager.livesChanged += delegate (int lives)
            {
                livesText.text = string.Format("{1} {0}", lives > 1 ? "Lives" : "Life", lives);
            };

        GameManager.DamageChanged += delegate (float damage)
            {
                damageSlider.value = damage;
                _damageFillArea.color = Color.Lerp(damageSliderColorMin, damageSliderColorMax, damage/damageSlider.maxValue); 
            };

        GameManager.StateChanged += OnStateChanged;
    }


    public void PauseGame()
    {
        GameManager.State = GameManager.STATE.Pause;
    }

    public void ResumeGame()
    {
        GameManager.State = GameManager.STATE.Running;
    }
    //private void OnScoreChanged(int score)
    //{
    // scoreText.text = string.Format("Score : {0}", GameManager.Score);
    //}

    private void OnStateChanged(GameManager.STATE state)
    {
        gameStateText.text = string.Format("Game {0}", state.ToString().ToUpper());
        pauseButton.gameObject.SetActive(state == GameManager.STATE.Running);
        pauseMenu.gameObject.SetActive(state != GameManager.STATE.Running);
        resumeButton.gameObject.SetActive(state != GameManager.STATE.Over);
    }
}

   

