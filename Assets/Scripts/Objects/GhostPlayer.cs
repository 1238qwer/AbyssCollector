using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Exerciser))]
[RequireComponent(typeof(ColliderEventGenerator))]
public class GhostPlayer : MonoBehaviour
{  
    private enum PlayerState
    {
        run,
        attack
    }
    private PlayerState state = PlayerState.run;

    [SerializeField] private Text scoreText;//ui매니저로
    [SerializeField] private GameObject gameOverUI;//ui매니저로
    [SerializeField] private MouseLook mouseLook;   
    [SerializeField] private GameObject punchParticle;
    [SerializeField] private Camera mainCam;
    
    [SerializeField] private Transform attackPos;
    [SerializeField] private Inventory inventory;
    [SerializeField] private float coolTime;

    private ObjectPooler objectPooler;
    private Exerciser exerciser;
    private Animator animator;
    public bool isAttack;
    private GameObject pickUpObject;
    private float score;
    private float elpaseTime;

    void Awake () {
        animator = GetComponentInChildren<Animator>();
        exerciser = GetComponent<Exerciser>();
        animator.Play("run");
        objectPooler = new ObjectPooler();
        objectPooler.AutoReturnPool(punchParticle, 5, 5);
    }
	
    public void ActiveAttack()
    {
        isAttack = true;
    }
    public void DeactiveAttack()
    {
        isAttack = false;
        animator.Play("run");
    }

	void Update () {
        
        score += Time.deltaTime * 10;
        int intScore = (int)score;
        scoreText.text = intScore.ToString() + "M";

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
        if (pickUpObject)
        {
            pickUpObject.transform.localPosition = new Vector3(transform.localPosition.x + 1.1f, pickUpObject.transform.localPosition.y, transform.localPosition.z-0.5f);
 
        }
    }

    //밑에다 주먹을 넣어서 주먹이 발동될때 콜라이더 제네레이터를 쓰자.
    public void OnEvent(GameObject eventObject)
    {
        if (eventObject.name.Contains("Ghost"))
        {
            if (isAttack)
            {
                GameObject particle = objectPooler.GetPool();
                particle.transform.position = attackPos.position;
                Ghost trap = eventObject.GetComponent<Ghost>();
                Exerciser exerciser = eventObject.GetComponent<Exerciser>();

                trap.animator.Play("Jump");
                //trap.transform.Rotate(-50, 0, 0);
                exerciser.DynamicDirectionChange(new Vector3(Random.Range(-50, 50), 40, 70));
            }
            else
            {
                animator.Play("Wave");
                exerciser.Stop(0);

                //Destroy(gameObject);

                gameOverUI.SetActive(true);
            }
        }

        if (eventObject.name.Contains("Fence"))
        {
            animator.Play("Wave");

            //Destroy(gameObject);

            gameOverUI.SetActive(true);

        }

        
        if (eventObject.tag == "CatchableGhost")
        {
            if (isAttack)
            {
                inventory.Add(eventObject.name);
                PickUp(eventObject);
            }
        }

        if (eventObject.tag =="CheckPoint")
        {
            if (pickUpObject)
            {
                Exerciser rb = pickUpObject.GetComponent<Exerciser>();


                rb.DynamicDirectionChange(new Vector3(20, 20, -3));
                pickUpObject = null;
            }
        }

    }

    public void PickUp(GameObject gameObject)
    {
        if (pickUpObject == null || pickUpObject.name != gameObject.name)
        {
            pickUpObject = Instantiate(gameObject, transform.position, Quaternion.identity);
            pickUpObject.transform.Rotate(-90, 0, 0);
        }

        Animator animator = gameObject.GetComponent<Animator>();

        gameObject.SetActive(false);
        pickUpObject.SetActive(true);

        
        //animator.Play("run");
    }
}
