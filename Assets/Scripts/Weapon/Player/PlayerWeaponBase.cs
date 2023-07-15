using UnityEngine;
using Zenject;

public abstract class PlayerWeaponBase : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int bulletsCount;

    protected ObjectsPool bulletsPool;

    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;

    private void Start()
    {
        bulletsPool.AddObjects(bulletPrefab, bulletsCount);
    }

    [Inject]
    private void Init(BulletsPool bulletsPool)
    {
        this.bulletsPool = bulletsPool;
    }

    protected virtual void Update()
    { 
        nextShotTime += Time.deltaTime;

        if (nextShotTime >= timeBetweenShots)
        {
            Shoot();
            nextShotTime = 0;
        }
    }

    protected abstract void Shoot();
}
