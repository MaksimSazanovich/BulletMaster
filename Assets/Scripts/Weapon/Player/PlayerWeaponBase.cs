using UnityEngine;
using Zenject;

public abstract class PlayerWeaponBase : WeaponBase
{
    [Inject]
    private void Init(BulletsPool bulletsPool)
    {
        this.bulletsPool = bulletsPool;
    }
}
