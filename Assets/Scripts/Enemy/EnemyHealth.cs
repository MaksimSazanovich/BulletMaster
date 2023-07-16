using UnityEngine;
using Zenject;

public class EnemyHealth : UnitHealth
{
    private PlayerHealth playerHealth;
    private EnemyDestruction enemyDestruction;
    public override void ApplyDamage(int damage)
	{
		base.ApplyDamage(damage);
	}

    [Inject]
    private void Init(PlayerHealth playerHealth)
    {
        this.playerHealth = playerHealth;
    }

    protected override void Start()
    {
        base.Start();
        enemyDestruction = GetComponent<EnemyDestruction>();
    }

    private void OnEnable()
    {
        playerHealth.OnDie += Die;
    }

    private void OnDisable()
    {
        playerHealth.OnDie -= Die;
    }

    public override void Die()
	{        
        transform.rotation = Quaternion.identity;
        enemyDestruction.Activate();
        base.Die();
    }
}