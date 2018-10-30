using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Exerciser))]
[RequireComponent(typeof(ColliderEventGenerator))]
public class GhostPlayer : MonoBehaviour
{  
    [SerializeField] private MouseLook mouseLook;   
    [SerializeField] private Camera mainCam;
    
    [SerializeField] private Inventory inventory;
    [SerializeField] private ParticleManager particleManager;

    [SerializeField] private GameObject attackObj;

    private Exerciser exerciser;
    private Animator animator;
    private StateComparator stateComparator;
    public bool isAttack;
    private CatchableGhost PickUpGhost;
    private float score;
    private float elpaseTime;
    
    void Awake () {
        animator = GetComponentInChildren<Animator>();
        exerciser = GetComponent<Exerciser>();
        stateComparator = GetComponent<StateComparator>();
    }
	
    public void ActiveAttack()
    {
        attackObj.SetActive(true);
        stateComparator.SetState("attack");
    }
    public void DeactiveAttack()
    {
        attackObj.SetActive(false);
        stateComparator.SetState("run");
    }

	void Update () {
        
        if (transform.localRotation.y >= 0)
        {
            if (transform.position.x <= 6.6f)
                exerciser.DynamicDirectionChange(new Vector3(Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }
        if (transform.localRotation.y <= 0)
        {
            if (transform.position.x >= -6.6f)
                exerciser.DynamicDirectionChange(new Vector3(-Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.Play("attack");
        }

        if (Input.GetMouseButton(0))
        {
            mouseLook.LookingMouse();
        }
    }

    public void LateUpdate()
    {
        mainCam.transform.position = new Vector3(transform.position.x - 5, mainCam.transform.position.y, mainCam.transform.position.z);
        if (PickUpGhost)
        {
            PickUpGhost.transform.localPosition = new Vector3(transform.localPosition.x + 0.35f, transform.localPosition.y-0.8f, transform.localPosition.z - 0.7f);
        }
    }

    public void HitGhost(GameObject ghost)
    {
        particleManager.CreateHitFX(attackObj.transform.position);
        particleManager.CreateGhostDisapearFX(ghost.transform.position);

        Ghost hitGhost = ghost.GetComponent<Ghost>();
        hitGhost.Hit();
    }
    //밑에다 주먹을 넣어서 주먹이 발동될때 콜라이더 제네레이터를 쓰자.
    public void OnEvent(GameObject eventObject)
    {
        if (eventObject.name.Contains("ghost"))
        {
            stateComparator.OnEvent("attack");
        }

        if (eventObject.name.Contains("Fence"))
        {
            animator.Play("die");
        }
     
        if (eventObject.tag == "CatchableGhost")
        {
            if (isAttack)
            {            
                PickUp(eventObject);
            }
        }

        if (eventObject.tag =="CheckPoint")
        {

        }
    }

    public void Die()
    {

    }

    public void OnCheckPoint()
    {
        if (PickUpGhost)
        {
            PickUpGhost.OnCheckPoint();
            PickUpGhost = null;
        }
    }

    public void PickUp(GameObject gameObject)
    {
        if (PickUpGhost)
        {
            PickUpGhost.Decatched();
        }

        PickUpGhost = gameObject.GetComponent<CatchableGhost>();
        animator.Play("catch");

        PickUpGhost.Catched();
        inventory.Add(gameObject.name);
    }
}
