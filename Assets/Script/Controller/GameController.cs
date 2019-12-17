using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get { return _instance; }
    }

    private bool _playing = true;
    public bool isPlaying { get { return this._playing; } }

    // Use this for initialization
    void Start()
    {
        if (!_instance) _instance = this;
    }

    public void StartGame()
    {
        this._playing = true;
    }

    public void PauseGame()
    {
        this._playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
