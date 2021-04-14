using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Area;
/// </summary>


[AddComponentMenu("Banquise/Game Area")]
public class GameArea : MonoBehaviour
{
    private Rect _area = new Rect(0,0,10,10);
    public Vector2 size;
    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    private Color gizmoWireColor;

    public Rect Area { get { return _area; } set{ _area = value; } }

   
    public void SetArea(Vector2 size)
    {
        Area = new Rect(size.x * -0.5f, size.y * -0.5f,size.x, size.y);
    }

    private void OnValidate()
    {
        SetArea(size);
        gizmoWireColor = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b,1);

    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(new Vector3(Area.center.x, Area.center.y, 0), new Vector3(Area.width, Area.height, 0));
        Gizmos.color = gizmoWireColor;
        Gizmos.DrawWireCube(new Vector3(Area.center.x, Area.center.y, 0), new Vector3(Area.width, Area.height, 0));
    }
}
