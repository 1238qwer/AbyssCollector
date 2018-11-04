using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocomotionController))]
[RequireComponent(typeof(Disappearer))]
[RequireComponent(typeof(ColliderEventGenerator))]
[RequireComponent(typeof(NameComparator))]
[RequireComponent(typeof(TagComparator))]
public class CatchableGhost : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    private Vector3 direction;
    private LocomotionController locomotionController;
    private Disappearer disappearer;
    private StateManager stateManager;
    private bool isArcadeGameing;
    private float ct;

    void Awake () {
        stateManager = GetComponentInChildren<StateManager>();
        disappearer = GetComponent<Disappearer>();
        animator = GetComponent<Animator>();
        locomotionController = GetComponent<LocomotionController>();
	}

    void Start()
    {
        if (gameObject.scene.name == "Arcade")
            isArcadeGameing = true;

        if (isArcadeGameing)
        {
            stateManager.State = "Arcade";
            //animator.Play("idle");
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
            stateManager.State = "Room";
            Disappearer disappearer = GetComponent<Disappearer>();
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            locomotionController.DynamicDirectionChange(transform.forward);
            disappearer.Deactivate = true;
            locomotionController.SetSpeed(1f);
            animator.Play("run");
        }
    }

    public void Catched()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        animator.Play("capture");
        disappearer.Deactivate = true;
    }

    public void Decatched()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        animator.Play("idle");
        disappearer.Deactivate = false;
    }

    public void OnCheckPoint()
    {

    }

}