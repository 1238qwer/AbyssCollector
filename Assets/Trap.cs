using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject obj;
    private int speed;
	// Use this for initialization
	void Awake () {
        Debug.Log(gameObject.gameObject.name);
        speed = Random.Range(1, 5);
	}
	
	// Update is called once per frame
	void Update () {
        obj.transform.position += new Vector3(0, speed, 0)* Time.deltaTime;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("충돌");
            Player player =  other.GetComponentInParent<Player>();
            StartCoroutine(player.Death());
        }
            
    }
}
