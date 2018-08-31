using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorkManager : MonoBehaviour {

    Camera camera;
    Animator animator;
    public GameObject menuImage;
	// Use this for initialization
	void Awake () {
        camera = GetComponent<Camera>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CameraPositionUp()
    {
        //camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y+Value, camera.transform.position.z);
        animator.Play("cameraUp");
    }

    float currentValue;
    public IEnumerator CorutainCameraPositionUp(int value)
    {      
        currentValue += Time.deltaTime;

        for(float i =0;i<=value;i++)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + i, camera.transform.position.z);

            yield return new WaitForSeconds(0.1f);

            StartCoroutine(CorutainCameraPositionUp(value));
        }      
    }

    public void CameraPositionDown()
    {
        //camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - Value, camera.transform.position.z);
        animator.Play("cameraDown");
    }

    public IEnumerator CorutainCameraPositionDown(int value)
    {
        for (float i = 0; i <= value; i ++)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - i, camera.transform.position.z);

            yield return new WaitForSeconds(0.1f);

            //StartCoroutine(CorutainCameraPositionDown(value));
        }
    }

    public void MenuAutoSetActive()
    {
        
        if (menuImage.activeSelf == true)
        {
            CameraPositionDown();
        }
        else
            CameraPositionUp();

    }

    public void MenuOpen()
    {
        menuImage.SetActive(true);
    }

    public void MenuClose()
    {
        menuImage.SetActive(false);
    }


}
