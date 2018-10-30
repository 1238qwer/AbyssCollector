using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    private int chase;
    private GhostPlayer player;
    private Exerciser exerciser;

    void Start () {
        animator = GetComponent<Animator>();
        exerciser = GetComponent<Exerciser>();
        animator.Play("run");

        transform.Rotate(new Vector3(-90, 180, 0));

        chase = Random.Range(0, 3);
        if (chase == 2)
        {
            if (!player)
                return;

            player =  GameObject.Find("Player").GetComponent<GhostPlayer>();
            Vector3 dir = player.transform.position - transform.position;
            exerciser.DynamicDirectionChange(dir);
        }    
    }

    public void Hit()
    {
        transform.Translate(0, 1, 0);
        exerciser.DynamicDirectionChange(new Vector3(0, 0, -15));
    }
}
