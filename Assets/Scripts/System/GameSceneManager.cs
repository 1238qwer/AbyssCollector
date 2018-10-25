using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class GameSceneManager : MonoBehaviour {

    [Serializable]
    public class SceneData
    {
        [Serializable]
        public enum SceneName
        {
           Arcade,
           Room          
        }
        public SceneName sceneName;

        public UnityEvent onSceneStart;
        public UnityEvent onScenePlay;
        public UnityEvent onSceneExit;
    }

    public SceneData[] sceneDatas;
    private string sceneName;
    private SceneData currentScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        sceneName = GetSceneName();
        Init();
    }

    private void Init()
    {
        foreach(SceneData item in sceneDatas)
        {
            if (item.sceneName.ToString() == sceneName)
            {
                currentScene = item;
                item.onSceneStart.Invoke();
            }
        }
    }

    private void Update ()
    {
        foreach (SceneData item in sceneDatas)
        {
            if (item.sceneName.ToString() == sceneName)
            {
                item.onScenePlay.Invoke();
            }
        }

        if (GetSceneName() != sceneName)
        {
            currentScene.onSceneExit.Invoke();
            sceneName = GetSceneName();
            Init();
        }
    }

    private string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
