using UnityEngine;
using System.Collections;

public class Gun : BaseWeapon
{
    public GameObject bulletPrefab;

    [SerializeField]
    protected float fireRate = 1f; // bullets in second

    protected float timeCount = 0f;

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected virtual void Fire() {}

    protected override Quaternion GetRotation()
    {
        return Quaternion.Euler(0, 0, -90);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        timeCount += Time.deltaTime;
        if (parentEntity != null && Input.GetMouseButton(0) && timeCount * fireRate >= 1)
        {
            timeCount = 0f;
            this.Fire();
        }
    }
}
