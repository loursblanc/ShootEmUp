using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 static public class GameManager 
{
    static private int _score;
    //static private int _highScore;
    
    const float maxDamage = 100;
    static private float _damage;
    static private int _lives =0;
    static public float Damage
    {
        get { return _damage; }
        set
        {
            if(value != _damage)
            {
                _damage = value;

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
        set { PlayerPrefs.SetInt("HighScore", value); }
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
                if (_lives <= 0) {
                    // TODO : Handle gameOver
                }


            }
        }
    }
}
