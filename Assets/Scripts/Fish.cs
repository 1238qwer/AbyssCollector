using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private Vector3 direction;
    private bool isCollection;

    private int speed;
    public Inventory inventory;

    // Use this for initialization
    void Start () {
        if (gameObject.scene.name == "Collect")
            isCollection = true;

        if (isCollection)
        {
            speed = Random.Range(1, 5);

            if (transform.position.x >= 0)
            {
                direction =
                new Vector3(-1, 0, 0) * Time.deltaTime;
                transform.Rotate(new Vector3(-90, -90, 0));
            }
            else
            {
                direction = new Vector3(1, 0, 0) * Time.deltaTime;
                transform.Rotate(new Vector3(-90, -90, -180));
            }
        }
        else
        direction = -transform.up;
	}
	
	// Update is called once per frame
	void Update () {
        if (isCollection)
            Locomotive();
        else
            transform.localPosition += direction * Time.deltaTime * 0.1f;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (isCollection)
        {
            if (other.tag == "Player")
            {
                Player player = other.GetComponentInParent<Player>();

                inventory.Add(name);

                Destroy(gameObject);
            }
        }
        else
        {
            direction = -direction;
            transform.Rotate(new Vector3(0, 0, 180));
        }
    }

    public void Locomotive()
    {
        Debug.Log(direction);
        transform.position += direction * Time.deltaTime * speed * 10;
    }
}
