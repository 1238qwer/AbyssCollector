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
    private bool isAttack;

    public float coolTime;
    private float elpaseTime;

    public Inventory inventory;

	void Awake () {
        animator = GetComponentInChildren<Animator>();
        animator.Play("run");
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
        score += Time.deltaTime;
        int intScore = (int)score;
        scoreText.text = intScore.ToString() + "M";

        currentMousePos = 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if (transform.localRotation.y >= 0)
        {
            if (transform.position.x >= 9.6f)
            {
                exerciser.DynamicDirectionChange(new Vector3(-Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            }
            exerciser.DynamicDirectionChange(new Vector3(transform.localRotation.y * 15,0,0));
        }
        if (transform.localRotation.y <= 0)
        {
            if (transform.position.x <= -7.6f)
            {
                exerciser.DynamicDirectionChange(new Vector3(transform.localRotation.y * 15, 0, 0));
            }
            exerciser.DynamicDirectionChange(new Vector3(-Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
        }
        //exerciser.DynamicDirectionChange(new Vector3(currentMousePos.x,0,0));

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("run");
            isAttack = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.Play("Jump");
            isAttack = true;
        }

        if (Input.GetMouseButton(0))
        {
            mouseLook.LookingMouse();
        }
    }

    public IEnumerator EventReceived(string id,GameObject eventObject)
    {
        if (id == "ghost")
        {
            if (isAttack)
            {
                Ghost trap = eventObject.GetComponent<Ghost>();
                Rigidbody rb = eventObject.GetComponent<Rigidbody>();

                trap.animator.Play("Jump");
                trap.transform.Rotate(-50, 0, 0);
                rb.AddForce(new Vector3(Random.Range(-1000, 1000), 800, 1500));
            }
            else
            {
                animator.Play("Wave");

                yield return new WaitForSeconds(1f);

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

        if (id == "zombie")
        {
            if (isAttack)
            {
                inventory.Add(id);
                Destroy(eventObject);
            }
        }
        if (id == "police")
        {
            if (isAttack)
            {
                inventory.Add(id);
                Destroy(eventObject);
            }
        }
        if (id == "female")
        {
            if (isAttack)
            {
                inventory.Add(id);
                Destroy(eventObject);
            }
        }
    }
}
