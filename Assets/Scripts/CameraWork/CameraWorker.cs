using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorker : MonoBehaviour {

    public MouseLook mouseLook;
	
	void Update () {
        if (Input.GetMouseButton(0))
        {
            LookingMouse();
        }
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"))* 1000 * Time.deltaTime);
    }

    public void LookingMouse()
    {
        transform.localPosition += new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y"));
    }
}
