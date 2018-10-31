using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoReturnPooler : MonoBehaviour {

    [Serializable]
    public class ReturnPoolData
    {
        public List<ObjectPooler.PoolData> autoReturnGameObjects = new List<ObjectPooler.PoolData>();
        public float originLiftTime;

        public ReturnPoolData(List<ObjectPooler.PoolData> pool,float originLiftTime)
        {
            this.autoReturnGameObjects = pool;
            this.originLiftTime = originLiftTime;
        }
    }

    public List<ReturnPoolData> returnPoolDatas = new List<ReturnPoolData>();

	public void Add(List<ObjectPooler.PoolData> autoReturnGameObjects)
    {
        ReturnPoolData tmp = new ReturnPoolData(autoReturnGameObjects, autoReturnGameObjects[0].lifeTime);
        returnPoolDatas.Add(tmp);
	}

    void Update()
    {
        foreach (ReturnPoolData item in returnPoolDatas)
        {
            foreach (ObjectPooler.PoolData data in item.autoReturnGameObjects)
            {
                if (data.origin.activeSelf == true)
                {
                    data.lifeTime -= Time.deltaTime;
                    if (data.lifeTime <= 0)
                    {
                        data.origin.SetActive(false);
                        data.lifeTime = item.originLiftTime;
                    }
                }
            }
        }
    }
}
