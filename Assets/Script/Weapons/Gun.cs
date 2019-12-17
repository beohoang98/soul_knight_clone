using UnityEngine;
using System.Collections;

public class Gun : BaseWeapon
{
    public GameObject bulletPrefab;
    protected float fireRate = 1f; // bullets in second
    protected float timeCount = 0f;

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected virtual void Fire() {}

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        timeCount += Time.deltaTime;
        if (timeCount * fireRate >= 1)
        {
            timeCount = 0f;
            this.Fire();
        }
    }
}
