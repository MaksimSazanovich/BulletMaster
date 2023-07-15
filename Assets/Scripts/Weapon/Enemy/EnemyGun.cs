using UnityEngine;
using UnityEngine.Events;

public class EnemyGun : EnemyWeaponBase
{
    [SerializeField] private UnityEvent OnShot;

    [SerializeField] private float offset;

    private bool canShoot = false;
    private Vector3 targetPosition;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(ActiveShoot), 1);
    }

    private void Update()
    {
        if (canShoot)
        Rotate();
    }
    public void Rotate()
    {
        if (Time.time > nextShotTime)
        {
            if(targetPosition != null)
            targetPosition = new Vector3(Random.Range(target.position.x - offset, target.position.x + offset), Random.Range(target.position.y - offset, target.position.y + offset), target.position.z);
            if (targetPosition.x < 0)
            {
                if(transform.rotation.eulerAngles.y == 180)
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f /* изменить!!! */, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                transform.localScale = new Vector3(1f, -1f, 1f);
            }
            else if (targetPosition.x > 0)
            {
                if (transform.rotation.eulerAngles.y == 180f)
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180f, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            OnShot.Invoke();
            Shoot();
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    protected override void Shoot()
    {
        currentBullet = bulletsPool.GetObject();
        if (currentBullet == null)
            Debug.Log("! billet");
        else
        {
            InitBullet();
        }
    }
    private void InitBullet()
    {
        currentBullet.transform.position = bulletStartPosition.position;
        currentBullet.transform.Rotate(bulletStartPosition.rotation.eulerAngles);
        currentBullet.SetActive(true);
    }

    private void ActiveShoot() => canShoot = true;
}