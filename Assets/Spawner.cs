using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("SPAWN")]
    public GameObject reference;
    [Header("SPAWNING")]
    [Range(0.001f,100f)] public float minrate = 1.0f;
    [Range(0.001f,100f)] public float maxrate = 1.0f;
    public int number = 5;
    public bool infinite; 

    private int _remaining;
    private float _timeStamp;

    [Header("LOCATIONS")]
    public GameArea area;

    // Start is called before the first frame update
    //void Start()
    //{
    //    _remaining = number;
    //    StartCoroutine(Spawn());
    //    //_timeStamp = Time.time;
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Time.time <= _timeStamp + rate)
    //        return;

    //    _timeStamp = Time.time;

    //    //if(_remaining > 0) 
    //    //{ 
    //        Instantiate(reference, transform.position, transform.rotation);
    //        _remaining--;
    //    //}
    //    if (!infinit && _remaining <= 0)
    //        this.enabled = false;  
    //}

    private IEnumerator Start()
    {
        _remaining = number;
        while (infinite || _remaining > 0)
        {
            //Vector3 _position = area.GetRandomPosition();
            Vector3 _position = area ? area.GetRandomPosition() : transform.position; 
            Instantiate(reference, _position, transform.rotation);
            _remaining--;

            yield return new WaitForSeconds(1 / Random.Range(minrate,maxrate));
        }
    }
}
