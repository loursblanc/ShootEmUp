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
    public Rect area = new Rect(0,0,10,10);

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (area.Contains(position))
            return;
        
        if (position.x < area.xMin)
        {
            position.x = area.xMax;
        }
        else
        {
            if (position.x > area.xMax)
            {
                position.x= area.xMin;
            }
        }


        if (position.y < area.yMin)
        {
            position.y = area.yMax;
        }
        else
        {
            if (position.y > area.yMax)
            {
                position.y = area.yMin;
            }
        }
        transform.position = position;
    }
}
