using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;
    public static LevelController Instance
    {
        get { return _instance; }
    }

    public GameObject loadingScreen;
    public Slider progress;
    private int currentLevel;

    // Use this for initialization
    void Start()
    {
        if (!_instance) _instance = this;
        else
        {
            Destroy(gameObject);
        }
    }


    public void startGame()
    {
        Debug.Log("load level");
        int levelSaved = PlayerPrefs.GetInt("level", 0);

        currentLevel = levelSaved + 1;
        StartCoroutine(loadScene(levelSaved + 1));
    }

    public void nextLevel()
    {
        Debug.Log("next level");

        gameObject.SetActive(true);
        int nextLevel = currentLevel + 1;
        PlayerPrefs.SetInt("level", currentLevel);

        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void returnBase()
    {
        StartCoroutine(loadScene(0));
    }

    IEnumerator loadScene(int level)
    {
        Debug.Log("load level " + level);
        progress.value = 0;
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);

        while (!operation.isDone)
        {
            progress.value = operation.progress * 100;
            Debug.Log($"Load {progress.value}%");
            yield return null;
        }

        loadingScreen.SetActive(false);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
