using UnityEngine;

public class PlayerWeaponSingle : PlayerWeaponBase
{
    [SerializeField] private Transform bulletStartPosition;
    protected override void Shoot()
    {
        var bullet = bulletsPool.GetObject();
        if (bullet == null)
            Debug.Log("! billet");
        else
        {
            bullet.transform.position = bulletStartPosition.position;
            bullet.transform.Rotate(bulletStartPosition.rotation.eulerAngles);
            bullet.SetActive(true);
        }
        
    }
}
