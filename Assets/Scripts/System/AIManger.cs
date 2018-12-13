using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManger : MonoBehaviour {

    public List<GameObject> attractions = new List<GameObject>();

    private CatchableLocomotionController catchableLocomotionController;

    private int rnd;
    private float ct;
    private Transform parents;
    private RoomManager roomManager;
    private Animator animator;

	// Use this for initialization
	void Awake () {

        animator = GetComponentInParent<Animator>();

        animator.Play("run");
        
        catchableLocomotionController = GetComponent<CatchableLocomotionController>();
        parents = catchableLocomotionController.Paraents;

        if (gameObject.scene.name == "Room")
        {
            roomManager = GameObject.FindObjectOfType<RoomManager>();
            foreach (var item in roomManager.movePoint)
            {
                attractions.Add(item);
            }

            rnd = Random.Range(0, attractions.Count);

            catchableLocomotionController.Goto(attractions[rnd]);
        }


    }
	
	// Update is called once per frame
	void Update () {

        

        if (gameObject.scene.name == "Room")
        {
            ct += Time.deltaTime;

            int stop;
            if (ct >= Random.Range(7, 15))
            {
                stop = Random.Range(0, 3);

                if (stop ==0)
                {
                    Debug.Log("멈춤");
                    catchableLocomotionController.Stop();
                    animator.Play("interaction");             
                }
                else
                {
                    rnd = Random.Range(0, attractions.Count);
                    animator.Play("run");

                    catchableLocomotionController.Goto(attractions[rnd]);
                    Debug.Log(parents.name + " 는 " + attractions[rnd] + " 로 가는중입니다.");
                }
                ct = 0;

            }
        }
	}
}
