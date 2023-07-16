public class PlayerHealth : UnitHealth
{
	public override void ApplyDamage(int damage)
	{
		base.ApplyDamage(damage);
	}

	public override void Die()
	{
		
		base.Die();
	}
}