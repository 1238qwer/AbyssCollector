using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CatchableLocomotionController))]
[RequireComponent(typeof(CatchableDisapearer))]
[RequireComponent(typeof(ColliderEventGenerator))]

public class CatchableGhost : Character
{
    [HideInInspector] public Animator animator;

    private Vector3 direction;
    private CatchableLocomotionController locomotionController;
    private Disappearer disappearer;
    private StateManager stateManager;
    private Transform myTransform;
    private bool isArcadeGameing;

    private ArcadeManager arcadeManager;

    private float ct;

    void Awake () {
        arcadeManager = GameObject.FindObjectOfType<ArcadeManager>();
        myTransform = transform.parent.transform;
        stateManager = GetComponentInChildren<StateManager>();
        disappearer = GetComponent<Disappearer>();
        animator = GetComponentInParent<Animator>();
        locomotionController = GetComponent<CatchableLocomotionController>();
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

    //public void Catched()
    //{
    //    transform.Rotate(new Vector3(0, 180, 0));
    //    animator.Play("capture");
    //    disappearer.Deactivate = true;
    //}

    //public void Decatched()
    //{
    //    transform.Rotate(new Vector3(0, 180, 0));
    //    animator.Play("idle");
    //    disappearer.Deactivate = false;
    //}


    public void OnCheckPoint()
    {
        myTransform.position = new Vector3(0, 0, 0);
        myTransform.Rotate(0, 180, 0);
        StartCoroutine(OnCheckPointAction());
    }

    float checkpointTime;
    private IEnumerator OnCheckPointAction()
    {
        checkpointTime += Time.deltaTime;

        animator.Play("run");
        myTransform.position += new Vector3(2,0,1) * Time.deltaTime;
       
        yield return null;

        Debug.Log("음?");
        if (checkpointTime >= 5.0f)
        {
            arcadeManager.LocomotionAllResume();
            Debug.Log("풀림");
            yield break;
        }

        StartCoroutine(OnCheckPointAction());
        
    }
}