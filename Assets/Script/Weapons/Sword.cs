using UnityEngine;
using System.Collections;

public class Sword : BaseWeapon
{

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected override Vector3 GetPosition()
    {
        return new Vector3(0f, 0.2f, -1);
    }

    protected override Quaternion GetRotation()
    {
        return Quaternion.Euler(0, 0, -90); // up
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
