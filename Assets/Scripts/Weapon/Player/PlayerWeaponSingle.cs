using UnityEngine;
using Zenject.SpaceFighter;

public class PlayerWeaponSingle : PlayerWeaponBase
{     
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
}
