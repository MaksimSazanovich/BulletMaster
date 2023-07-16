using System;
using UnityEngine;

public abstract class UnitHealth : MonoBehaviour, IDamageable
{
	[SerializeField] protected int maxHealth;
	protected int health;

	protected internal Action<int> OnHealthChanged;

    protected internal event Action OnDie;

    protected virtual void Start()
	{ 
		health = maxHealth;
	}
	public virtual void ApplyDamage(int damage)
	{
		if (damage < 0)
		{
			Debug.Log("Error");
			return;
		}

		health -= damage;

		OnHealthChanged?.Invoke(health); 

		if (health <= 0)
		{ 
			Die();
		}

	}

	public virtual void Die()
	{
        OnDie?.Invoke();
        gameObject.SetActive(false);
	}
}