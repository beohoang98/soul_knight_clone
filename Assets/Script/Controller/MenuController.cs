using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject SettingMenu;

    void Start () {
        if (!SettingMenu || !MainMenu)
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

    public void Quit()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
