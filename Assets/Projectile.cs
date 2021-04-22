using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [System.NonSerialized]
    public float range = 5;
    private float _distance; 
    public float speed = 0.5f;
    private AudioSource _audio;
   

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.fixedDeltaTime), Space.Self);
        _distance += speed * Time.fixedDeltaTime;
        if (_distance > range)
            Destroy(gameObject);// TODO : use Object pooling 
    }
}
