using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 static public class GameManager 
{
    const float maxDamage = 100;
    static private float _damage;
    static private int _lives;
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
                    //TODO :  Lives --
                    _damage = 0; 
                }
                Debug.Log("Damage : " + _damage);
            }
        }
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
