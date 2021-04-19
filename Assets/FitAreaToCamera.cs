using UnityEngine;
using System.Collections;

/// <summary>
/// Fit area to camera.
/// </summary>
[AddComponentMenu ("Jikkou Publishing/Fit Area to Camera")]
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour
{
	private GameArea Area
	{
		get { return GetComponent<GameArea>(); }
	}

	private void Awake ()
	{
		FitToMainCamera();
	}

	private void FitToCamera (Camera cam)
	{
		Area.Size = new Vector2 (cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
		transform.position = (Vector2)cam.transform.position;
		transform.rotation = cam.transform.rotation;
	}

	private void FitToMainCamera ()
	{
		FitToCamera(Camera.main);
	}

	private void Reset ()
	{
		FitToMainCamera();
	}
}