using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyHealth : UnitHealth
{
    public override void ApplyDamage(int damage)
	{
		base.ApplyDamage(damage);
	}

    public override void Die()
	{
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}