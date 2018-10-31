using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InputManager : MonoBehaviour {

    private GhostPlayer ghostPlayer;
    private MouseLook mouseLook;

    private void Awake()
    {
        ghostPlayer = GetComponent<GhostPlayer>();
        mouseLook = GetComponent<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ghostPlayer.Attack();
        }

        if (Input.GetMouseButton(0))
        {
            mouseLook.LookingMouse();
        }
    }
    //   [Serializable]
    //   public class KeyData
    //   {
    //       public string key;
    //       public UnityEvent onGetKey;
    //       public UnityEvent onGetKeyDown;
    //       public UnityEvent onGetKeyUp;
    //   }

    //   public KeyData[] keyDatas;


    //void Update () {

    //       if (Input.anyKey)
    //       {
    //           foreach(KeyData data in keyDatas)
    //           {
    //               if (Input.an)
    //           }
    //       }

    //   }

}
