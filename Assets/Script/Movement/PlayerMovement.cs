using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 momentVec = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            momentVec += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            momentVec += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            momentVec += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            momentVec += Vector2.right;
        }

        this.rigid.velocity = momentVec.normalized * this.speed;
        this.animator.SetBool("move", momentVec.magnitude > 0f);
    }
}
