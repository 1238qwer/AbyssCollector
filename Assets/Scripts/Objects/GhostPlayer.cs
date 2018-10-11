using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Exerciser))]
[RequireComponent(typeof(ColliderEventGenerator))]
public class GhostPlayer : MonoBehaviour
{  
    [SerializeField] private Text scoreText;//ui매니저로
    [SerializeField] private GameObject gameOverUI;//ui매니저로
    [SerializeField] private MouseLook mouseLook;   
    [SerializeField] private GameObject punchParticle;
    
    [SerializeField] private Transform attackPos;
    [SerializeField] private Inventory inventory;
    [SerializeField] private float coolTime;

    private ObjectPooler objectPooler;
    private Exerciser exerciser;
    private Animator animator;
    private bool isAttack;
    private GameObject pickUpObject;
    private float score;
    private float elpaseTime;

    void Awake () {
        animator = GetComponentInChildren<Animator>();
        exerciser = GetComponent<Exerciser>();
        animator.Play("run");
        objectPooler = new ObjectPooler();
        objectPooler.Pool(punchParticle,5);
        Debug.Log(objectPooler);
    }
	
    public void ActiveAttack()
    {
        isAttack = true;
    }
    public void DeactiveAttack()
    {
        isAttack = false;
    }

	void Update () {
        score += Time.deltaTime * 10;
        int intScore = (int)score;
        scoreText.text = intScore.ToString() + "M";

        if (transform.localRotation.y >= 0)
        {
            if (transform.position.x <= 7.6f)
                exerciser.DynamicDirectionChange(new Vector3(Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }
        if (transform.localRotation.y <= 0)
        {
            if (transform.position.x >= -7.6f)
                exerciser.DynamicDirectionChange(new Vector3(-Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }


        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("run");
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
        if (pickUpObject)
        {
            pickUpObject.transform.localPosition = new Vector3(transform.localPosition.x + 1.1f, pickUpObject.transform.localPosition.y, transform.localPosition.z-0.5f);
            pickUpObject.transform.rotation = transform.rotation;
        }
    }

    //밑에다 주먹을 넣어서 주먹이 발동될때 콜라이더 제네레이터를 쓰자.
    public void OnCollide(string id,GameObject eventObject)
    {
        if (id == "Ghost")
        {
            if (isAttack)
            {
                GameObject particle = objectPooler.GetPool();
                particle.transform.position = attackPos.position;
                Ghost trap = eventObject.GetComponent<Ghost>();
                Exerciser exerciser = eventObject.GetComponent<Exerciser>();

                trap.animator.Play("Jump");
                trap.transform.Rotate(-50, 0, 0);
                exerciser.DynamicDirectionChange(new Vector3(Random.Range(-50, 50), 40, 70));
            }
            else
            {
                animator.Play("Wave");
                exerciser.Stop(0);

                Destroy(gameObject);

                gameOverUI.SetActive(true);
            }
        }

        if (id == "Fence")
        {
            animator.Play("Wave");

            Destroy(gameObject);

            gameOverUI.SetActive(true);

        }

        
        if (id == "zombie"|| id == "police"|| id == "female")
        {
            if (isAttack)
            {
                inventory.Add(id);
                PickUp(eventObject);
            }
        }

        if (id == "checkpoint")
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
        pickUpObject = gameObject;
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
        Animator animator = gameObject.GetComponent<Animator>();
        animator.Play("run");
        Disappearer disappearer = gameObject.GetComponent<Disappearer>();
        Destroy(disappearer);
    }
}
