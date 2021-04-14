using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Objectif : 
 * Faire boucler la position de l'objet dans une zone rectangulaire
 * lorsque l'objet sort du bord droit, il revient a gauche.
 */
[AddComponentMenu ("Banquise/Transform Looper")]
public class TransformLooper : MonoBehaviour
{
    //public Rect area = new Rect(0,0,10,10);
    public GameArea gameArea;
    private Vector3 areaSpacePosition;

    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;

        areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

        if (gameArea.Area.Contains(areaSpacePosition))
            return;

        if (areaSpacePosition.x < gameArea.Area.xMin)
        {
            areaSpacePosition.x = gameArea.Area.xMax;
        }
        else
        {
            if (areaSpacePosition.x > gameArea.Area.xMax)
            {
                areaSpacePosition.x= gameArea.Area.xMin;
            }
        }


        if (areaSpacePosition.y < gameArea.Area.yMin)
        {
            areaSpacePosition.y = gameArea.Area.yMax;
        }
        else
        {
            if (areaSpacePosition.y > gameArea.Area.yMax)
            {
                areaSpacePosition.y = gameArea.Area.yMin;
            }
        }
        //transform.position = position;
        transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
    }
}
