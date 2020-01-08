using UnityEngine;
using System.Collections;

public class GunnyEnemy : BaseEnemy
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float speed = 5f;

    float _speed = 0f;

    [SerializeField]
    int fireRate = 2;

    float timeCount = 0f;

    SpriteRenderer renderer;
    Rigidbody2D rigidbody;
    Vector2 direction;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        timeCount += Time.deltaTime;
        if (this.target)
        {
            LookAtPlayer();
            DoIfSeePlayer();
        }
    }

    void LookAtPlayer()
    {
        direction = this.target.transform.position - transform.position;
        renderer.flipX = direction.x < 0;
        rigidbody.position += direction.normalized * _speed * Time.deltaTime;
    }

    void DoIfSeePlayer()
    {
        string[] layers = new string[] { "Player", "MapWall" };
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, 50f, LayerMask.GetMask(layers));
        Debug.Log(hit2D.collider);
        Color color = Color.blue;

        if (hit2D.collider && hit2D.collider.tag == TAG.PLAYER)
        {
            color = Color.red;
            _speed = speed;
            if (timeCount * fireRate > 1)
            {
                timeCount = 0f;
                this.Fire();
            }
        }

        Debug.DrawRay(transform.position, direction, color);
    }

    void Fire()
    {
        if (bulletPrefab)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.FromToRotation(Vector2.up, direction));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _speed = 0;
    }
}
