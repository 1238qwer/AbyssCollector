using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostPlayer : MonoBehaviour
{  
    public Text scoreText;
    public GameObject gameOverUI;
    public MouseLook mouseLook;
    public Exerciser exerciser;
    public GameObject punchParticle;
    public ObjectPooler objectPooler;  
    public Transform attackPos;
    public Inventory inventory;
    private Animator animator;
    private bool isAttack;
    private GameObject pickUpObject;
    private float score;
    private float elpaseTime;

    public float coolTime;

    void Awake () {
        animator = GetComponentInChildren<Animator>();
        animator.Play("run");
        objectPooler.Pool(punchParticle,5);
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
