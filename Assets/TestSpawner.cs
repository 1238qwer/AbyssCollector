using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour {

    public GameObject testObj;
    private GameObject currnetObj;
	// Use this for initialization
	void Start () {
        currnetObj = Instantiate(testObj, transform.position, Quaternion.identity);
        currnetObj.transform.Rotate(-90, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
