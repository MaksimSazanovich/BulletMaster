using UnityEngine;

public class HeartBonus : BaseBonus
{
	[SerializeField] private int healValue;

	protected override void OnCollisionEnter2D(Collision2D collision)
	{
		base.OnCollisionEnter2D(collision);

		if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
			playerHealth.Heal(healValue);
	}
}