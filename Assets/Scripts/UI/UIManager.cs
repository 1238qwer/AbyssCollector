using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class UIManager : ScriptableObject {

    public void GotoRoomScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoCollectScene()
    {
        SceneManager.LoadScene("Arcade");
    }
}
