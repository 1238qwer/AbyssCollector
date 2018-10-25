using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class UIManager : ScriptableObject {

    public void GotoRoomScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GotoCollectScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Arcade");
    }
}
