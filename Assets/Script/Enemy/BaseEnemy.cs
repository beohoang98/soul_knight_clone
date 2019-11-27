using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
    public int maxHealth = 10;
    protected float _health = 0f;

    public Slider healthbar;

    public float health
    {
        get { return _health; }
        set { Debug.LogError("Cannot modify health"); }
    }

    // Use this for initialization
    protected void Start()
    {
        _health = maxHealth;
        healthbar.maxValue = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Sword")
        {
            SwordAttack swordAttack = collision.GetComponent<SwordAttack>();
            if (swordAttack.attacking)
            {
                Debug.Log("Attacked" + swordAttack.baseWeapon.damage);
                swordAttack.attacking = false;
                this.GotDamage(swordAttack.baseWeapon.damage, collision);
            }
        }
        else if (collision.tag == "Bullet")
        {

        }
    }

    protected void GotDamage(float damage, Collider2D collider)
    {
        this.OnAttacked(collider);
        if (_health >= damage)
        {
            _health -= damage;
        } else
        {
            _health = 0;
            this.OnDie();
        }
    }

    protected virtual void OnAttacked(Collider2D collider) {}
    protected virtual void OnDie() {
        Destroy(gameObject);
    }

    // Update is called once per frame
    protected void Update()
    {
        healthbar.value = this.health;
        healthbar.gameObject.SetActive(healthbar.value < maxHealth);
    }
}
