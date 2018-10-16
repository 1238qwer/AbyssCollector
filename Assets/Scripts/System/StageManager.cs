using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GameObject stage;
    private GameObject currentStage;
    public float coolTime;
    private float ct;

	void Update () {
        ct += Time.deltaTime;
        if (ct >= coolTime)
        {
            currentStage = Instantiate(stage,transform.position,Quaternion.identity);
            ct = 0;
        }
       
	}
}
