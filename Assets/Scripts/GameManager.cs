using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameManager
{

    public delegate void ScoreChange (int score);
    public delegate void LivesChange (int score);
    public delegate void DamageChange(float damage);

    static private int _score;
    static public event ScoreChange ScoreChanged;
    static public event ScoreChange HighScoreChanged;
    //static private int _highScore;

    public const  float maxDamage = 100;
    static private float _damage;
    static public event DamageChange DamageChanged;
    static private int _lives =5;
    static public event LivesChange livesChanged;
    static public float Damage
    {
        get { return _damage; }
        set
        {
            if(value != _damage)
            {
                _damage = value;
                if (DamageChanged != null)
                    DamageChanged(_damage);

                if (_damage >= maxDamage)
                {
                    Lives--;
                    _damage = 0; 
                }
                Debug.Log("Damage : " + _damage);
            }
        }
    }
    static public int Score
    {
        get { return _score; }
        set
        {
            if (value != _score)
            {
                _score = value;

                if (ScoreChanged != null)
                    ScoreChanged(_score);
                if (_score > HighScore)
                    HighScore = _score;
                
                Debug.Log(_score);
            }
        }
    }
    static public int HighScore
    {
        get { return PlayerPrefs.GetInt("HighScore", 0); }
        // _highScore = PlayerPrefs.GetInt("HighScore",0);
        //return _highScore; 
        //}
        set { PlayerPrefs.SetInt("HighScore", value);
            if (HighScoreChanged != null)
                HighScoreChanged(value);
        }
            
            
    //if (value != _highScore)
    //{
    //  _highScore = value;
    //PlayerPrefs.SetInt("HighScore", _highScore);
    //Debug.Log(_highScore);
    //}
    //}
}


    static public int Lives
    {
        get { return _lives; }
        set
        {
            if (value != _lives)
            {
                _lives = value;
                if (livesChanged != null)
                    livesChanged(_lives);
                if (_lives <= 0) {
                    // TODO : Handle gameOver
                }


            }
        }
    }
}
