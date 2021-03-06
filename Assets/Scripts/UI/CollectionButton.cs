﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionButton : MonoBehaviour {

    private CatchableGhost origin;
    private string description;
    private Inventory inventory;

    public void Init(CatchableGhost origin,string description,Inventory inventory)
    {
        this.origin = origin;
        this.inventory = inventory;
        this.description = description;      
    }

    Vector3 point;

    public void Update()
    {
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 1));
        if (fish&&!isLocate)
        fish.transform.position = point;
        
    }
    CatchableGhost fish;
    public void Spawn()
    {
        isLocate = false;
        GameObject testAqua = GameObject.Find("AquaLium");

        fish = Instantiate(origin, point, Quaternion.identity).GetComponent<CatchableGhost>();
        fish.transform.Rotate(0, 0, UnityEngine.Random.Range(-90, 90));
        //fish.transform.Rotate(0, 0, UnityEngine.Random.Range(-90, 90));
        inventory.gettingItem.Remove(origin.name);

       
        //Fish fish = Instantiate(inventory.Get(id), testAqua.transform.position, Quaternion.identity).GetComponent<Fish>();
    }

    bool isLocate;
    public void Locate()
    {
        isLocate = true;
    }
}
