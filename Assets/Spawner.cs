using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[Header ("SPAWN")]
	public GameObject reference;

	[Header ("SPAWNING")]
	[Range (0.001f, 100f)] public float minRate = 1.0f;
	[Range (0.001f, 100f)] public float maxRate = 1.0f;
	public int number = 5;
	public bool infinite;

	private int _remaining;

	[Header ("LOCATIONS")]
	public GameArea area;
	private Transform player;
	public float minDistanceFromPlayer;

	[Header ("VELOCITY")]
	[Range (-180f, 180f)] public float angle;
	[Range (0, 360f)] public float spread = 30f;
	[Range (0, 10)] public float minStrength = 1f;
	[Range (0, 10)] public float maxStrength = 10f;

	[Header ("ANIMATOR")]
	public string animatorSpawningParameterName = "Spawning";
	public float animatorDelayIn = 1;
	public float animatorDelayOut = 1;

	private Animator animator;
	private int spawningHashID;

	void Awake ()
	{
		animator = GetComponent<Animator>();
		if (animator)
			spawningHashID = Animator.StringToHash(animatorSpawningParameterName);
	}

	private IEnumerator Start ()
	{
		_remaining = number;

		if (minDistanceFromPlayer > 0)
		{
			GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
			if (playerGO)
				player = playerGO.transform;
			else
				Debug.LogWarning("No Player Found.");
		}

		if (animator)
		{
			animator.SetBool(spawningHashID, true);
			yield return new WaitForSeconds(animatorDelayIn);
		}

		while (infinite || _remaining > 0)
		{
			Vector3 _position = area ? area.GetRandomPosition() : transform.position;

			if (player && Vector3.Distance(_position, player.position) < minDistanceFromPlayer)
			{
//				Debug.Log(_position);
				Vector3 debugPos = _position;
				Debug.DrawLine(transform.position, debugPos);
				_position = (_position-player.position).normalized * minDistanceFromPlayer;
				Debug.DrawLine(debugPos, _position);
//				Debug.Break();
			}

			// TODO : Use Object Pooling
			GameObject obj = Instantiate(reference, _position, transform.rotation);

			Rigidbody2D rb2d = obj.GetComponent<Rigidbody2D>();
			if (rb2d)
			{
				float angleDelta = Random.Range(-spread*0.5f, spread*0.5f);
				float angle_ = angle + angleDelta;
				Vector2 direction = new Vector2 (Mathf.Sin(Mathf.Deg2Rad*angle_), Mathf.Cos(Mathf.Deg2Rad*angle_));
				direction *= Random.Range(minStrength, maxStrength);
				rb2d.velocity = direction;
			}

			_remaining --;

			yield return new WaitForSeconds(1/Random.Range(minRate, maxRate));
		}

		if (animator)
		{
			yield return new WaitForSeconds(animatorDelayOut);
			animator.SetBool(spawningHashID, false);
		}

		gameObject.SetActive(false);
	}
}