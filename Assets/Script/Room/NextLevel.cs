using UnityEngine;
using System.Collections;
using TMPro;

public class NextLevel : MonoBehaviour
{
    public TextMeshPro text;
    private bool isPlayerOpen = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.gameObject.SetActive(isPlayerOpen);
        if (isPlayerOpen && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Next Level");
            LevelController.Instance.gameObject.SetActive(true);
            LevelController.Instance.nextLevel();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayerOpen = collision.tag == TAG.PLAYER;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TAG.PLAYER)
        {
            isPlayerOpen = false;
        }
    }
}
