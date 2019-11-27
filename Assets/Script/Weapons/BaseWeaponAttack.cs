using UnityEngine;
using System.Collections;

public class BaseWeaponAttack : MonoBehaviour
{
    public BaseWeapon baseWeapon;

    // Use this for initialization
    protected void Start()
    {

    }

    protected virtual void StartAttack()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.StartAttack();
        }
    }
}
