using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTrap : MonoBehaviour
{
    public string id;
    private int speed;
    Vector3 direction;
    public Inventory inventory;
    // Use this for initialization
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        Locomotive();
    }

    public void Locomotive()
    {
        Debug.Log(direction);
        transform.position += direction * Time.deltaTime * speed * 10;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponentInParent<Player>();

            inventory.Add(id);

            Destroy(gameObject);
        }

    }
}
