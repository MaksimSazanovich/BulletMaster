using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
	private Transform target;
	[SerializeField] private float speed;

	[Inject]
	private void Init(PlayerHealth player)
	{
		target = player.transform;
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
	}
}