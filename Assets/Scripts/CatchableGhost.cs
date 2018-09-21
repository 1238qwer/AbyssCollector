using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableGhost : MonoBehaviour
{

    private Vector3 direction;
    private Exerciser exerciser;
    private bool isArcadeGameing;

    [HideInInspector] public Animator animator;

    private float ct;

    void Start () {
        animator = GetComponent<Animator>();
        exerciser = GetComponent<Exerciser>();

        if (gameObject.scene.name == "Demo")
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
                direction = new Vector3(0, 0,1) * Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, 0));
            }
        }
        else
        {
            Disappearer disappearer = GetComponent<Disappearer>();
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            exerciser.DynamicDirectionChange(transform.forward);
            Destroy(disappearer);
            exerciser.SetSpeed(0.5f);
            //transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
	}
	
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (isArcadeGameing)
        {

        }
        else
        {
            transform.Rotate(new Vector3(0, Random.Range(90, 180), 0));
            exerciser.DynamicDirectionChange(transform.forward);
            
        }
    }
}