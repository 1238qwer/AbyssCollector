using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private Vector3 direction;
    private bool isCollection;

    private int speed;
    public Inventory inventory;

    public Animator animator;
    public Rigidbody rb;

    public float lifeTime;
    private float ct;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (gameObject.scene.name == "Demo")
            isCollection = true;

        if (isCollection)
        {
            animator.Play("run");
            speed = Random.Range(1, 5);

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
            transform.Rotate(new Vector3(0, 0, 0));
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            direction = -transform.up;
        }
	}
	
	// Update is called once per frame
	void Update () {

        ct += Time.deltaTime;
        if (ct > lifeTime && gameObject.name != "Enviroment")
            Destroy(gameObject);

        if (isCollection)
            Locomotive();
        else
        {
            transform.localPosition += direction * Time.deltaTime * 0.1f;
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollection)
        {
            if (other.tag == "Player")
            {
                GhostPlayer player = other.GetComponentInParent<GhostPlayer>();

                StartCoroutine(player.Death(this, rb));

                inventory.Add(name);

            }
        }
        else
        {
            direction = -direction;
            transform.Rotate(new Vector3(0, 0, 180));
        }
    }

    public void Locomotive()
    {
        Debug.Log(direction);
        transform.position += new Vector3(0,0,-1) * Time.deltaTime * speed * 10;
    }
}
