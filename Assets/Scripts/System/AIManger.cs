using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManger : MonoBehaviour {

    public GameObject[] attraction;

    private CatchableLocomotionController catchableLocomotionController;

    private int rnd;
    private float ct;
    private Transform parents;
	// Use this for initialization
	void Awake () {
        catchableLocomotionController = GetComponent<CatchableLocomotionController>();
        parents = catchableLocomotionController.Paraents;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.scene.name == "Room")
        {
            ct += Time.deltaTime;

            if (ct >= 5.0f)
            {
                rnd = Random.Range(0, 5);

                if (rnd == 3)
                {
                    Debug.Log("카페가야징");
                    catchableLocomotionController.Goto(attraction[0]);
                }

                ct = 0;
            }
        }
	}
}
