using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturnPooler : MonoBehaviour {

    private List<ObjectPooler.PoolData> autoReturnGameObjects = new List<ObjectPooler.PoolData>();
    private float originLiftTime;

	public void Init (List<ObjectPooler.PoolData> autoReturnGameObjects)
    {
        this.autoReturnGameObjects = autoReturnGameObjects;
        originLiftTime = autoReturnGameObjects[0].lifeTime;
	}

    void Update()
    {
        foreach (ObjectPooler.PoolData item in autoReturnGameObjects)
        {
            if (item.origin.activeSelf == true)
            {
                item.lifeTime -= Time.deltaTime;
                if (item.lifeTime <= 0)
                {
                    item.origin.SetActive(false);
                    item.lifeTime = originLiftTime;
                }
            }
        }
    }
}
