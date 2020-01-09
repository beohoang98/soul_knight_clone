using UnityEngine;
using System.Collections;

public class BasicGun : Gun
{
    protected override void Fire()
    {
        base.Fire();
        Debug.Log("Fire " + transform.localEulerAngles);

        Vector2 bulletStartPos = transform.position + transform.localRotation * Vector2.up;

        GameObject bulletObj = Instantiate(this.bulletPrefab, bulletStartPos, this.transform.localRotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetDamage(this.damage);
        }
        bulletObj.SetActive(true);
    }
}
