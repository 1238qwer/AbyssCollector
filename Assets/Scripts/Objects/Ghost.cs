using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    int chase;
    private GhostPlayer player;
    private Exerciser exerciser;
    void Start () {
        animator = GetComponent<Animator>();
        exerciser = GetComponent<Exerciser>();

        chase = Random.Range(0, 3);
        if (chase == 2)
        {         
            player =  GameObject.Find("Player").GetComponent<GhostPlayer>();
            Vector3 dir = player.transform.position - transform.position;
            exerciser.DynamicDirectionChange(dir);
        }
        animator.Play("run");
    }
	
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
