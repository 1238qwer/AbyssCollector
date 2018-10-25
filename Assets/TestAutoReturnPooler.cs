using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAutoReturnPooler : MonoBehaviour {

    public ObjectPooler objectPooler;
    private float ct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ct += Time.deltaTime;
        if (ct >= 10.0f)
        {
            ct = 0;
        }
	}
}
