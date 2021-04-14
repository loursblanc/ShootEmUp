//#define REMOTE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipController : MonoBehaviour
{
    private Vector2 delta = Vector2.zero;
    //private Transform transformComponent;

    // Start is called before the first frame update
    void Start()
    {
        //transformComponent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
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
        

    }
}
