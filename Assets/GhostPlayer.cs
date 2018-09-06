using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostPlayer : MonoBehaviour {

    private Animator animator;
    private Vector3 direction;
    private Vector3 lastMousePos;
    private Vector3 currentMousePos;
    private float score;
    public Text scoreText;
    public GameObject gameOverUI;

    public float speed;

    public GameObject cube;
    private bool isAttack;
	// Use this for initialization
	void Awake () {
        animator = GetComponentInChildren<Animator>();
        animator.Play("run");
    }
	
	// Update is called once per frame
	void Update () {
        score += Time.deltaTime;
        int intScore = (int)score;
        scoreText.text = intScore.ToString() + "M";

        currentMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("run");
            isAttack = false;
        }
        if (Input.GetMouseButton(0))
        {
            
            if (currentMousePos.x >= lastMousePos.x)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                transform.Rotate(0, Time.deltaTime * 10, 0);
            }
            if (currentMousePos.x <= lastMousePos.x)
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
                transform.Rotate(0, -Time.deltaTime * 10, 0);
            }
            
        }
        lastMousePos = currentMousePos;
        if (Input.GetMouseButtonUp(0))
        {
            animator.Play("Jump");
            isAttack = true;
        }
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(currentMousePos), Time.deltaTime );



    }

    public IEnumerator Death(Fish trap,Rigidbody rb)
    {
        if (isAttack)
        {
            Debug.Log("공격");
            trap.animator.Play("Jump");
            trap.transform.Rotate(-50, 0, 0);
            rb.AddForce(new Vector3(Random.Range(-1000  ,1000), 800, 1500));
        }
        else
        {
            Debug.Log("그냥");
            animator.Play("Wave");

            yield return new WaitForSeconds(1f);

            Destroy(gameObject);

            gameOverUI.SetActive(true);
        }

    }
}
