using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;
    public static LevelController Instance
    {
        get { return _instance; }
    }

    // Use this for initialization
    void Start()
    {
        LevelController[] instances = FindObjectsOfType<LevelController>();
        if (instances.Length > 0)
        {
            Destroy(this);
        }

        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
