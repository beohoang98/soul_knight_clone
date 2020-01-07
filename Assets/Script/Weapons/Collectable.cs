using UnityEngine;
using System.Collections;
using UnityEditor;

public class Collectable : MonoBehaviour
{
    BaseWeapon attachedWeapon;
    Player player;

    // Use this for initialization
    void Start()
    {
        attachedWeapon = GetComponent<BaseWeapon>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player == null || collision.tag != TAG.PLAYER || attachedWeapon.parentEntity == player.gameObject)
        {
            return;
        }

        if (Input.GetButton("Swap"))
        {
            player.weapon.GetComponent<BaseWeapon>().parentEntity = null;

            player.weapon = gameObject;
            attachedWeapon.parentEntity = player.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TAG.PLAYER && attachedWeapon.parentEntity == null)
        {
            ShowInfo(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TAG.PLAYER)
        {
            ShowInfo(false);
        }
    }

    private void ShowInfo(bool isShow = false)
    {
        if (!isShow)
        {
            UIController.Instance.showWeaponOnHover(false);
        } else
        {
            float damageDiff = attachedWeapon.damage - player.weapon.GetComponent<BaseWeapon>().damage;
            UIController.Instance.updateWeaponOnHover(
                attachedWeapon.name, 
                attachedWeapon.damage,
                damageDiff
            );
        }   
    }
}
