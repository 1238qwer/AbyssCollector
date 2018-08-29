using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationController : MonoBehaviour {

    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.Play("Land");
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
