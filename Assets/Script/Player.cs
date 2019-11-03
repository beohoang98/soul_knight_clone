using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer renderer;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.followMouse();
    }

    private void followMouse()
    {
        Vector2 mousePosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
            );
        direction.Normalize();

        if (direction.x < 0)
        {
            this.renderer.flipX = true;
        } else
        {
            this.renderer.flipX = false;
        }
        
        this.rigid.velocity = direction.normalized * this.speed;
    }
}
