using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
    private static SceneGlobalManager instance;
    public static SceneGlobalManager Instance { get { return instance; } }

    public string gameScene;
    public string resultsScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(LoadMenuScene());
    }

    public IEnumerator LoadMenuScene()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Menu");
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            yield return null;
        }

        loadAsync.allowSceneActivation = true;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Additive);
    }

    public void LoadResultsScene()
    {
        SceneManager.LoadSceneAsync(resultsScene, LoadSceneMode.Additive);
    }

    public void UnloadGameAndResultsScenes()
    {
        SceneManager.UnloadSceneAsync(gameScene);
        SceneManager.UnloadSceneAsync(resultsScene);
    }
}
