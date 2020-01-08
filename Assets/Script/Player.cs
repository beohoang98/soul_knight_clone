using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
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
            this.spriteRenderer.flipX = true;
        } else
        {
            this.spriteRenderer.flipX = false;
        }
    }
}
