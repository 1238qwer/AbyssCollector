using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour {

    public GameObject fish;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    float ct;
    int random;
	void Update () {
        ct += Time.deltaTime;
        if (ct >= 5.0f)
        {
            random = Random.Range(0, 100);

            if (random >= 90)
            {
                GameObject spawn =
                Instantiate(fish, transform.position, Quaternion.identity);

               
            }
            ct = 0;
        }

	}
}
