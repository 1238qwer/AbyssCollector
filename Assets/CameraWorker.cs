using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorker : MonoBehaviour {

    public MouseLook mouseLook;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            LookingMouse();
        }
        //transform.localPosition += new Vector3(0, Input.GetAxis("Mouse ScrollWheel"),0 );
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"))* 1000 * Time.deltaTime);
    }

    public void LookingMouse()
    {
        transform.localPosition += new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y"));

            //float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            //rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            //transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}
