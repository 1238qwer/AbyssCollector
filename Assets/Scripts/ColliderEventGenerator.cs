using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventGenerator : MonoBehaviour {

    [SerializeField] private string id;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GhostPlayer player = other.GetComponentInParent<GhostPlayer>();

            StartCoroutine(player.EventReceived(id, this.gameObject));
        }
    }
}
