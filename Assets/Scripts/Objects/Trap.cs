using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject obj;
    private int speed;
    private AudioSource audioSource;
    public Animator animator;
    private Rigidbody rb;


	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
        speed = Random.Range(10, 15);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (animator)
        animator.Play("run");
	}
	
	// Update is called once per frame
	void Update () {

        obj.transform.position += new Vector3(0, 0, -15)* Time.deltaTime;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GhostPlayer player =  other.GetComponentInParent<GhostPlayer>();
            //StartCoroutine(player.Death(this,rb));
        }
            
    }
}
