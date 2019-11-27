using UnityEngine;
using System.Collections;

public class SwordAttack : BaseWeaponAttack
{
    public Animation atkAnimation;
    public bool attacking = false;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        attacking = false;
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        if (attacking) return;

        this.attacking = true;
        atkAnimation.Play();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (this.attacking)
        {
            this.attacking = atkAnimation.isPlaying;
        }
        else
        {
            atkAnimation.Stop();
        }
    }
}
