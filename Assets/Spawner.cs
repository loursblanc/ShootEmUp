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
    private Transform player;
    public float minDistanceFromPlayer; 

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
        if (minDistanceFromPlayer > 0) { 
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            if (playerGO)
            {
                player = playerGO.transform;
            }else
            {
                Debug.LogWarning("No player found");
            }
        }
        _remaining = number;
        while (infinite || _remaining > 0)
        {
            //Vector3 _position = area.GetRandomPosition();
            Vector3 _position = area ? area.GetRandomPosition() : transform.position;
            if(player &&  Vector3.Distance(_position, player.position) < minDistanceFromPlayer){
                Vector3 debugPos = _position; 
                Debug.DrawLine(transform.position, debugPos);
                _position = (_position - player.position).normalized * minDistanceFromPlayer;
                Debug.DrawLine(debugPos, _position);
                //Debug.Break();
            }

            Instantiate(reference, _position, transform.rotation);
            _remaining--;

            yield return new WaitForSeconds(1 / Random.Range(minrate,maxrate));
        }
    }
}
