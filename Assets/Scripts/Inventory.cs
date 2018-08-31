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

    public List<Fish> GetAll()
    {
        List<Fish> tmp = new List<Fish>();

        foreach (string item in gettingFisies)
        {
            Fish currentItem = Resources.Load<GameObject>("SailCharacterPack/Prefabs/" + item).GetComponent<Fish>();

            tmp.Add(currentItem);

        }

        return tmp;
    }


}
