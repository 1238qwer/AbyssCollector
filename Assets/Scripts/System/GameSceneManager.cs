using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneManager : MonoBehaviour {

    public UnityEvent OnSceneLoad;
    public UnityEvent OnSceneUpdate;
    public UnityEvent OnSceneExit;

    private void Start()
    {
        OnSceneLoad.Invoke();
    }

    private void Update()
    {
        OnSceneUpdate.Invoke();
    }

    private void OnDisable()
    {
        OnSceneExit.Invoke();
    }

}
