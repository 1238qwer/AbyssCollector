using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UION : MonoBehaviour {

    public GameObject defaultUI;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void UIOnOff()
    {
        defaultUI.gameObject.SetActive(!defaultUI.activeSelf);
    }
}
