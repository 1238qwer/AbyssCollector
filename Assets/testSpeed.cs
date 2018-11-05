using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpeed : MonoBehaviour {

    public float time;
    public float ct;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= 1.0f)
        {
            Debug.Log(transform.position.z);
        }
	}
}
