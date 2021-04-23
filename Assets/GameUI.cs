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

    private void Awake()
    {
        _damageFillArea = damageSlider.fillRect.GetComponent<Image>();
        damageSlider.maxValue = GameManager.maxDamage;
    }


    private void Start()
    {
        livesText.text = string.Format("{0} : {01}",GameManager.Lives > 1 ? "Lives" : "Life", GameManager.Lives);
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
                livesText.text = string.Format("{0} : {01}", lives > 1 ? "Lives" : "Life", lives);
            };

        GameManager.DamageChanged += delegate (float damage)
            {
                damageSlider.value = damage;
                _damageFillArea.color = Color.Lerp(damageSliderColorMin, damageSliderColorMax, damage/damageSlider.maxValue); 
            };
    }



    //private void OnScoreChanged(int score)
    //{
    // scoreText.text = string.Format("Score : {0}", GameManager.Score);
    //}







}
