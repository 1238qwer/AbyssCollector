using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

    public List<string> gettingFisies = new List<string>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string id)
    {
        gettingFisies.Add(id);
    }

    GameObject currentItem;
    public GameObject Get(string id)
    {
        foreach(string item in gettingFisies)
        {
            if (item == id)
            {
                currentItem = Resources.Load<GameObject>("SailCharacterPack/Prefabs/" + id);
                
                return currentItem;
            }          
        }

        return null;
    }

    public void Spawn(string id)
    {
        GameObject testAqua = GameObject.Find("AquaLium");
        GameObject fish = Instantiate(Get(id), testAqua.transform.position, Quaternion.identity);

        fish.transform.Rotate(0, 0, Random.Range(-90, 90));

        if (fish != null)
        {
            fish.AddComponent<Fish>();
            DestroyImmediate(fish.GetComponent<FishTrap>());

            gettingFisies.Remove(id);

        }     
    }
}
