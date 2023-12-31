using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    [SerializeField] private float timeBetweenAttacks;
    private float nextAttackTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        nextAttackTime += Time.deltaTime;
        if (nextAttackTime >= timeBetweenAttacks)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(damage);
                nextAttackTime = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            nextAttackTime = 0f;
        }
    }
}