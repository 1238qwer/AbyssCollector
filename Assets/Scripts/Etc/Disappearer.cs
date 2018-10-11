using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearer : MonoBehaviour {

    public float lifeTime;
    private float currentTime;

	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime >= lifeTime)
            Destroy(gameObject);
	}
}
