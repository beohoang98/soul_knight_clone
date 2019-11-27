using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour
{
    public GameObject parentEntity;
    public float damage = 1f;

    // Use this for initialization
    protected void Start()
    {

    }

    protected virtual Vector3 GetPosition()
    {
        return new Vector3(0, 0, -1);
    }

    protected virtual Quaternion GetRotation()
    {
        return Quaternion.Euler(0, 0, 0); // up
    }

    // Update is called once per frame
    protected void Update()
    {
        if (parentEntity != null)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forward = mouse - (Vector2)this.transform.position;
            float rotationDeg = Mathf.Atan2(forward.y, forward.x) * 180 / Mathf.PI;
            float flipRotation = (rotationDeg < 90 && rotationDeg > -90) ? 0 : 180;
            float localRotationDeg = flipRotation > 0 ? 180 - rotationDeg : rotationDeg;

            this.transform.position = parentEntity.transform.position + this.GetPosition();
            this.transform.rotation = Quaternion.Euler(0, flipRotation, localRotationDeg) * this.GetRotation();
        }
    }
}
