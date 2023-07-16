using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBonus : BaseBonus
{
	[SerializeField] private float attackRange;
	[SerializeField] private int attackDamage;
    [SerializeField] private LayerMask enemyLayer;

    protected override void Activate()
	{
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D damageableObject in hitObjects)
        {
            damageableObject.GetComponent<IDamageable>().ApplyDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}