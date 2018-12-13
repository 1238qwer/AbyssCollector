using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : MonoBehaviour {

    public LocomotionController[] locomotionControllers;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LocomotionAllStop()
    {
        locomotionControllers = GameObject.FindObjectsOfType<LocomotionController>();

        foreach (var item in locomotionControllers)
        {
            item.speed = 0;
        }
    }

    public void LocomotionAllResume()
    {
        foreach (var item in locomotionControllers)
        {
            item.speed = 1;
        }
    }
}
