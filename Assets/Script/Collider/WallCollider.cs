using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.collider.name;
        Debug.Log("Wall collision: " + name);

        switch (name)
        {
            case "Player":
                collision.collider
                    .gameObject
                    .GetComponent<Rigidbody2D>()
                    .velocity = new Vector2(0, 0);
                break;

            default:
                return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
