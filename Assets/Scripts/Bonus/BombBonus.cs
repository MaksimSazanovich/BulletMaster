using UnityEngine;

public class BombBonus : BaseBonus
{
	[SerializeField] private float attackRange;
	[SerializeField] private int attackDamage;
    [SerializeField] private LayerMask enemyLayer;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            Activate();
        }
    }

    private void Activate()
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