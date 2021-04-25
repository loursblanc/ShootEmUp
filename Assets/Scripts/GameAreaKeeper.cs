using UnityEngine;
using System.Collections;

/*
 * Objectif :
 * Faire boucler la position de l'objet dans une zone rectangulaire.
 * Lorsque l'objet sors sur le bord droit, il revient à gauche.
 */

[AddComponentMenu ("Jikkou Publishing/GameAreaKeeper")]
public class GameAreaKeeper : MonoBehaviour
{
//	public Rect area = new Rect (0, 0, 10, 10);
	public GameArea gameArea;
	private Vector3 areaSpacePosition;

	private void Start ()
	{
		if (!gameArea)
			gameArea = GameArea.Main;
	}

	void FixedUpdate ()
	{
		areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

		if (gameArea.Area.Contains(areaSpacePosition))
			return;

		if (areaSpacePosition.x < gameArea.Area.xMin)
			areaSpacePosition.x = gameArea.Area.xMax;
		else if (areaSpacePosition.x > gameArea.Area.xMax)
			areaSpacePosition.x = gameArea.Area.xMin;

		if (areaSpacePosition.y < gameArea.Area.yMin)
			areaSpacePosition.y = gameArea.Area.yMax;
		else if (areaSpacePosition.y > gameArea.Area.yMax)
			areaSpacePosition.y = gameArea.Area.yMin;

		transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
	}
}