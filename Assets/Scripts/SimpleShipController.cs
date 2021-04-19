//#define REMOTE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipController : MonoBehaviour
{

    public float thrustPower = 1;
    public float steerPower = 1; 

    
    private Rigidbody2D _rigidbody2D;
    private Vector2 delta = Vector2.zero;
    //private Transform transformComponent;
    private Vector2 _force = Vector2.zero;
    private float _torque;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //transformComponent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR || REMOTE
    if(Input.touchCount > 0)
        {
            Touch t = Input.touches[0];
            if(t.phase == TouchPhase.Moved)
            {
                delta = t.deltaPosition;
            }
        }
#else
         delta.x = Input.GetAxis("Horizontal");
         delta.y = Input.GetAxis("Vertical");
#endif        
        transform.Translate(0, delta.y, 0);
        transform.Rotate(0, 0, -delta.x);

        _force.y = delta.y * thrustPower;
        _torque = -delta.x * steerPower;

        _rigidbody2D.AddRelativeForce(_force);
        _rigidbody2D.AddTorque(_torque);
        

    }
}
