using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerateManager : MonoBehaviour {

    [SerializeField] private TrapGenerator[] trapGenerators;

    public float coolTime;
    float ct;

    public GameObject origin;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ct += Time.deltaTime;
        if (ct >= coolTime)
        {
            GameObject trap = Instantiate(origin, trapGenerators[Random.Range(0,3)].transform.position, Quaternion.identity);
            trap.transform.rotation = new Quaternion(90, 90, 0, 0);
            ct = 0;
        }
    }
}
