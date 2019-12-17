using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuController : MonoBehaviour {
    public Canvas canvas;
    public GameObject MainMenu;
    public GameObject SettingMenu;

    void Start () {
        if (!SettingMenu || !MainMenu || !canvas)
        {
            Debug.LogError("menu object missing");
            throw new System.Exception("menu object missing");
        }
        this.returnMain();
    }

    public void openSetting()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void returnMain()
    {
        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }

    public void Toggle()
    {
        Debug.Log("Menu toggle");
        if (GameController.Instance.isPlaying)
        {
            GameController.Instance.PauseGame();
        } else
        {
            GameController.Instance.StartGame();
        }
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
    }

    public void ReturnBase()
    {
        LevelController.Instance.returnBase();
    }

    public void Quit()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Toggle();
        }
	}
}
