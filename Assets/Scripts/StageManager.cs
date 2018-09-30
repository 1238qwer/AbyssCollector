using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GameObject stage;
    private GameObject currentStage;
    public float coolTime;
    private float ct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ct += Time.deltaTime;
        if (ct >= coolTime)
        {
            currentStage = Instantiate(stage,transform.position,Quaternion.identity);
            ct = 0;
        }
       
	}
}
