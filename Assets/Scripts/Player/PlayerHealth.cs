public class PlayerHealth : UnitHealth, IHealable
{
	public override void ApplyDamage(int damage)
	{
		base.ApplyDamage(damage);
	}

	public override void Die()
	{		
		base.Die();
	}

	public void Heal(int healValue)
	{
		if (health < 3)
			health += healValue;
		if(health > maxHealth)
			health = maxHealth;
		OnHealthChanged?.Invoke(health);
	}
}