using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private Vector3 direction;
	// Use this for initialization
	void Start () {
        direction = -transform.up;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += direction * Time.deltaTime * 0.1f;
	}

    private void OnTriggerEnter(Collider other)
    {
        direction = -direction;
        transform.Rotate(new Vector3(0,0,180));
    }
}
