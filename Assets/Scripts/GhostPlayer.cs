using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostPlayer : MonoBehaviour
{

    private float score;
    public Text scoreText;

    private Animator animator;
    private Vector3 lastMousePos;
    private Vector3 currentMousePos;

    public GameObject gameOverUI;
    public MouseLook mouseLook;
    public Exerciser exerciser;
    public bool isAttack;
    private GameObject pickUpObject;

    public GameObject punchParticle;
    public ObjectPooler objectPooler;

    public float coolTime;
    private float elpaseTime;

    public Inventory inventory;

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

        currentMousePos = 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));


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
            pickUpObject.transform.localPosition = new Vector3(transform.localPosition.x + 1.1f, pickUpObject.transform.localPosition.y, transform.localPosition.z-0.3f);
            pickUpObject.transform.rotation = transform.rotation;
        }
    }

    public IEnumerator EventReceived(string id,GameObject eventObject)
    {
        if (id == "ghost")
        {
            if (isAttack)
            {
                objectPooler.GetPool();
                Ghost trap = eventObject.GetComponent<Ghost>();
                Exerciser exerciser = eventObject.GetComponent<Exerciser>();

                trap.animator.Play("Jump");
                trap.transform.Rotate(-50, 0, 0);
                exerciser.DynamicDirectionChange(new Vector3(Random.Range(-50, 50), 40, 70));
            }
            else
            {
                animator.Play("Wave");
                exerciser.Stop();

                yield return new WaitForSeconds(3f);

                Destroy(gameObject);

                gameOverUI.SetActive(true);
            }
        }

        if (id == "fence")
        {
            animator.Play("Wave");

            yield return new WaitForSeconds(1f);

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
