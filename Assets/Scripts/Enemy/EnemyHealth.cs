using System;
using UnityEngine;

public class EnemyHealth : UnitHealth
{
    public event Action OnDie;
    public override void ApplyDamage(int damage)
	{
		base.ApplyDamage(damage);
	}

    public override void Die()
	{
        OnDie?.Invoke();
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}