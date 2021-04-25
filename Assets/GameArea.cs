using UnityEngine;
using System.Collections;

/// <summary>
/// Defines a Rectangular Game Area.
/// </summary>
[AddComponentMenu ("Jikkou Publishing/Game Area")]
public class GameArea : MonoBehaviour
{
	[HideInInspector]
	[SerializeField]
	private Rect _area = new Rect (0, 0, 10, 10);
	public Rect Area
	{
		get { return _area; }
		set { _area = value; }
	}

	public Color gizmoColor = new Color (0, 0, 1, 0.2f);
	private Color gizmoWireColor;

	static private GameArea _main;
	static public GameArea Main
	{
		get
		{
			if (_main == null)
			{
				_main = (GameArea) GameObject.FindObjectOfType(typeof (GameArea));
				if (_main == null)
				{
					GameObject go = new GameObject ("Game Area : Main");
					_main = go.AddComponent<GameArea>();
					go.AddComponent<FitAreaToCamera>();
				}
			}
			return _main;
		}
		set
		{
			_main = value;
		}
	}

	public Vector2 size;
	public Vector2 Size
	{
		get { return Area.size ; }
		set
		{
			size = value;
			Area = new Rect (size.x * -0.5f, size.y * -0.5f, size.x, size.y);
		}
	}

	private void OnValidate ()
	{
		Size = size;
		gizmoWireColor = new Color (gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
	}

	private void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube (new Vector3 (Area.center.x, Area.center.y, 0), new Vector3 (Area.width, Area.height, 0));
		Gizmos.color = gizmoWireColor;
		Gizmos.DrawWireCube (new Vector3 (Area.center.x, Area.center.y, 0), new Vector3 (Area.width, Area.height, 0));
	}

	public Vector3 GetRandomPosition ()
	{
		Vector3 vector3 = Vector3.zero;
		vector3.x = Random.Range(Area.xMin, Area.xMax);
		vector3.y = Random.Range(Area.yMin, Area.yMax);
		vector3 = transform.TransformPoint(vector3);
		return vector3;
	}
}