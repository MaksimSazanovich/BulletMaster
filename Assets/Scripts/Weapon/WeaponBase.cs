using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected int bulletsCount;

    [SerializeField] protected Transform bulletStartPosition;

    [SerializeField] protected float timeBetweenShots;
    protected float nextShotTime;

    protected GameObject currentBullet;

    protected ObjectsPool bulletsPool;

    protected virtual void Start()
    {
        bulletsPool.AddObjects(bulletPrefab, bulletsCount);
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