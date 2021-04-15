using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fit area to camera
/// </summary>


[AddComponentMenu("Banquise/Fit Area To Camera")]
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour
{
    private GameArea Area
    {
        get { return GetComponent<GameArea>(); }
    }

    private void FitToCamera (Camera cam)
    {
        Area.SetArea(new Vector2 (cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        transform.position = cam.transform.position;
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        FitToCamera(Camera.main);
    }

    private void Reset()
    {
        FitToMainCamera();
    }

    private void Awake()
    {
        FitToMainCamera();

    }
}
