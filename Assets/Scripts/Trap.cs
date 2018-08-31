using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject obj;
    private int speed;
    private AudioSource audioSource;
	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
            Player player =  other.GetComponentInParent<Player>();
            StartCoroutine(player.Death());
        }
            
    }
}
