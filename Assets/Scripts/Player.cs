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
    public Rigidbody rb;

    private AudioSource audioSource;


    public bool click;
	// Use this for initialization
	void Awake () {
        rb = GetComponentInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameOverUI.SetActive(false);
        point = Vector3.up;
        direction = Vector3.back;
        transform.LookAt(direction);
    }
	
	// Update is called once per frame
	void Update () {

        score += Time.deltaTime ;
        int intScore = (int)score;
        scoreText.text =intScore.ToString() + "M";


        //if (Input.GetKey(KeyCode.A) && transform.position.x >= -1.6f)
        //{
        //    transform.localPosition += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;

        //    click = true;
        //}
        //if (Input.GetKey(KeyCode.D) && transform.position.x <= 1.6f)
        //{
        //    transform.localPosition += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        //    transform.Rotate(new Vector3(0, -turnSpeed, 0));
        //    click = false;
        //}
        //if (Input.GetKey(KeyCode.W) && transform.position.y <= 4.6f)
        //    transform.localPosition += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        //if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.6f)
        //    transform.localPosition += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

        transform.position += direction * Time.deltaTime * 0.3f;
        //if (direction.x >= 0)
        //{
        //    if (transform.rotation.y >= -80)
        //        transform.Rotate(new Vector3(0, -1, 0));
        //}
        //else
        //{
        //    if (transform.rotation.y <= 80)
        //        transform.Rotate(new Vector3(0, 1, 0));
        //}


        if (!((transform.position.x >= -2.5f && transform.position.x <= 2.5f) && (transform.position.y <= 4.5f && transform.position.y >= -4.5f)))
        {
            direction = Vector3.zero;
            //rb.Sleep();
        }


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 3f);


    }

    public IEnumerator Death()
    {
        animator.Play("Wave");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);

        gameOverUI.SetActive(true);
        
    }

    public GameObject cube;
    Vector3 point = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 back = -Vector3.forward;
    public void DirectionChange()
    {
        Debug.Log("으,ㅁ?");
        animator.Play("Jump");
        audioSource.Play();

        click = !click;

        Vector3 oldDircetion = direction;
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        direction = point - transform.position;


        //transform.LookAt(back, direction);
        //Instantiate(cube, point, Quaternion.identity);
        //if ((point.x >= -3f && point.x <= 3f) && (point.y >= -5f && point.y <= 5f))
        //{

        //rb.Sleep();
        //rb.AddForce(Vector3.Normalize(direction) * 100f);
        //if (!(transform.position.x >= -1.6f && transform.position.x <= 1.6f) && (transform.position.y <= 4.6f && transform.position.y >= -4.6f))
        //{
        //    rb.Sleep();

        //}

        //}
        //else
        //{
        //    rb.Sleep();
        //    rb.AddForce(Vector3.Normalize(point) * 100f);
        //}
    }




}
