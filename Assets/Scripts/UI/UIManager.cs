using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu]
public class UIManager : ScriptableObject {

    [SerializeField] private Text scoreText;//ui매니저로
    [SerializeField] private GameObject gameOverUI;//ui매니저로

    private float score;

    public void Init()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        gameOverUI = GameObject.Find("GameOverUI");
    }

    public void ScroeUp()
    {
        score += Time.deltaTime * 10;
        int intScore = (int)score;
        scoreText.text = intScore.ToString() + "M";
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void GotoRoomScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoCollectScene()
    {
        SceneManager.LoadScene("Arcade");
    }
}
