using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearer : MonoBehaviour {

    public bool Deactivate;
    public float lifeTime;
    protected float currentTime;

	void Update () {

        if (Deactivate)
        {
            return;
        }

        currentTime += Time.deltaTime;
        if (currentTime >= lifeTime)
        {
            gameObject.SetActive(false);
            currentTime = 0;
        }
    }
}
