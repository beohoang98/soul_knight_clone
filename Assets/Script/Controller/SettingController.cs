using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    private static SettingController _instance;
    public static SettingController Instance
    {
        get { return _instance; }
    }

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    public static Dictionary<string, int[]> options = new Dictionary<string, int[]>{
        { "1920x1080", new int[]{ 1920, 1080, 0 } },
        { "0", new int[]{ 1920, 1080, 0 } },

        { "1280x720", new int[]{ 1280, 720, 1 } },
        { "1", new int[]{ 1280, 720, 1 } },

        { "640x360", new int[]{ 640, 360, 2 } },
        { "2", new int[]{ 640, 360, 2 } },
    };

    // Use this for initialization
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
        } else
        {
            Destroy(this);
        }

        string resolutionSaved = PlayerPrefs.GetString("resolution", "640x360");
        int fullscreenSaved = PlayerPrefs.GetInt("fullscreen", 0);

        fullscreenToggle.isOn = fullscreenSaved > 0;
        Screen.fullScreen = fullscreenSaved > 0;

        resolutionDropdown.value = SettingController.options[resolutionSaved][2];
        this.changeResolution(resolutionDropdown);
    }

    public void setFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        PlayerPrefs.SetInt("fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void changeResolution(TMP_Dropdown dropdown)
    {
        string optionStr = dropdown.value.ToString();
        int w = options[optionStr][0];
        int h = options[optionStr][1];

        Screen.SetResolution(w, h, Screen.fullScreen);
        PlayerPrefs.SetString("resolution", w + "x" + h);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
