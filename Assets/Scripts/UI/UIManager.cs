﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject menuImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
