using UnityEngine;
using System.Collections;

public class BasicGun : Gun
{
    protected override void Fire()
    {
        base.Fire();
        Debug.Log("Fire " + transform.localEulerAngles);

        GameObject bulletObj = Instantiate(this.bulletPrefab, this.transform.position, this.transform.localRotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetDamage(this.damage);
        }
        bulletObj.SetActive(true);
    }
}
