using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGhostGenerator : MonoBehaviour {

    public Inventory inventory;
    public ObjectGenerater objectGenerater;

    private List<CatchableGhost> spawnGhost = new List<CatchableGhost>();

	// Use this for initialization
	void Awake () {
        spawnGhost = inventory.GetAll();
        objectGenerater.ManualSpawn(spawnGhost);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
