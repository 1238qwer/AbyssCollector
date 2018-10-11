using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exerciser))]
[RequireComponent(typeof(ColliderEventGenerator))]
[RequireComponent(typeof(NameComparator))]
public class CatchableGhost : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    private Vector3 direction;
    private Exerciser exerciser;
    private bool isArcadeGameing;
    private float ct;

    void Awake () {
        animator = GetComponent<Animator>();
        exerciser = GetComponent<Exerciser>();
	}

    void Start()
    {
        if (gameObject.scene.name == "Arcade")
            isArcadeGameing = true;

        if (isArcadeGameing)
        {
            if (transform.position.x >= 0)
            {
                direction =
                new Vector3(0, 0, 1) * Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, 0));
            }
            else
            {
                direction = new Vector3(0, 0, 1) * Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, 0));
            }
        }
        else
        {
            Disappearer disappearer = GetComponent<Disappearer>();
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            exerciser.DynamicDirectionChange(transform.forward);
            Destroy(disappearer);
            exerciser.SetSpeed(1f);
            animator.Play("walk");
        }
    }

}