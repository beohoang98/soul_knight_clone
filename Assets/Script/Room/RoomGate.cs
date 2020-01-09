using UnityEngine;
using System.Collections;

public class RoomGate : MonoBehaviour
{
    public delegate void OnEnterCallback();
    private OnEnterCallback enterCallback;
    
    // Use this for initialization
    void Start()
    {
        
    }

    
    public void onEnter(OnEnterCallback callback)
    {
        this.enterCallback = callback;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == TAG.GATE_START)
        {
            if (this.enterCallback != null)
            {
                this.enterCallback.Invoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
