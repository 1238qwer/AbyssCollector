using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowCam : MonoBehaviour {

    [SerializeField] private GameObject followTo;

    [Serializable]
    public enum Option
    {
        ONLY_X,
        ONLY_Y,
        ONLY_Z,
        ALL
    }
    public Option option;

	void LateUpdate () {

		if (option == Option.ONLY_X)
        {
            transform.position = new Vector3(followTo.transform.position.x - 5, transform.position.y, transform.position.z);
        }
        else if (option == Option.ONLY_Y)
        {
            transform.position = new Vector3(transform.position.z, followTo.transform.position.y - 5, transform.position.z);
        }
        else if (option == Option.ONLY_Z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, followTo.transform.position.z - 5);
        }
        else
        {
            transform.position = new Vector3(followTo.transform.position.x - 5, followTo.transform.position.x - 5, followTo.transform.position.x - 5);
        }
    }
}
