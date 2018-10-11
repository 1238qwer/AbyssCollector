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

    public List<CatchableGhost> GetAll()
    {
        List<CatchableGhost> tmp = new List<CatchableGhost>();

        foreach (string item in gettingItem)
        {
            CatchableGhost currentItem = Resources.Load<GameObject>("Prefabs/CatchableGhost/" + item).GetComponent<CatchableGhost>();

            tmp.Add(currentItem);

        }

        return tmp;
    }


}
