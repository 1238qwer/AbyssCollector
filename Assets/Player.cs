using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    private Animator animator;
    private float score;
    public Text scoreText;
    public GameObject gameOverUI;

    public Inventory inventory;


    bool click;
	// Use this for initialization
	void Awake () {
        animator = GetComponentInChildren<Animator>();
        gameOverUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        score += Time.deltaTime ;
        scoreText.text = score.ToString();
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -1.6f)
        {
            transform.localPosition += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, turnSpeed, 0));
            click = true;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 1.6f)
        {
            transform.localPosition += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, -turnSpeed, 0));
            click = false;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 4.6f)
            transform.localPosition += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.6f)
            transform.localPosition += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;


        //if (click)
        //    transform.localPosition += new Vector3(moveSpeed, -moveSpeed, 0) * Time.deltaTime;
        //else
        //    transform.localPosition += new Vector3(-moveSpeed, -moveSpeed, 0) * Time.deltaTime;

    }

    public IEnumerator Death()
    {
        animator.Play("Jump");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);

        gameOverUI.SetActive(true);
        
    }

    public void DirectionChange()
    {
        click = !click;
    }




}
