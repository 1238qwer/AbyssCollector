using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject menuImage;
    public CameraWorkManager mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuOpen()
    {
        menuImage.SetActive(true);
        //mainCam.CameraPositionUp(1f);
        mainCam.CameraPositionDown();
    }

    public void MenuClose()
    {
        menuImage.SetActive(false);
        //mainCam.CameraPositionUp(-1f);
        mainCam.CameraPositionUp();
    }

    public void MenuAutoSetActive()
    {
        //menuImage.SetActive(!menuImage.activeSelf);
        if (menuImage.activeSelf == false)
        {
            mainCam.CameraPositionDown();
        }
        else
            mainCam.CameraPositionUp();
    }

    public void GotoRoomScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoCollectScene()
    {
        SceneManager.LoadScene(1);
    }
}
