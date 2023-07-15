using UnityEngine;
using Zenject;

public abstract class EnemyWeaponBase : WeaponBase
{
    protected Transform target;

    [Inject]
    private void Init(PlayerHealth player, EnemyBulletsPool enemyBulletsPool)
    {
        target = player.transform;
        bulletsPool = enemyBulletsPool;
    }
}