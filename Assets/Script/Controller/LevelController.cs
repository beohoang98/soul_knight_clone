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

    // Use this for initialization
    void Start()
    {
        if (!_instance) _instance = this;
    }


    public void startGame()
    {
        Debug.Log("load level");
        int levelSaved = PlayerPrefs.GetInt("level", 0);
        StartCoroutine(loadScene(levelSaved + 1));
    }

    IEnumerator loadScene(int level)
    {
        Debug.Log("load level " + level);
        progress.value = 0;
        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);

        while (!operation.isDone)
        {
            progress.value = operation.progress * 100;
            yield return null;
        }

        loadingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
