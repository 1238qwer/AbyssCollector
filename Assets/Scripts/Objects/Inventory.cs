using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

    public List<string> gettingItem = new List<string>();

    public void Add(string id)
    {
        gettingItem.Add(id);
    }

    GameObject currentItem;
    public GameObject Get(string id)
    {
        foreach(string item in gettingItem)
        {
            if (item == id)
            {
                currentItem = Resources.Load<GameObject>("Prefabs/CatchableGhost/" + id);
                
                return currentItem;
            }          
        }

        return null;
    }

    public List<GameObject> GetAll()
    {
        List<GameObject> tmp = new List<GameObject>();

        foreach (string item in gettingItem)
        {
            GameObject currentItem = Resources.Load<GameObject>("Prefabs/CatchableGhost/" + item);

            tmp.Add(currentItem);
        }

        return tmp;
    }


}
