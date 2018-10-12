using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour{

    public class PoolData
    {
        public GameObject origin;
        public float lifeTime;

        public PoolData(GameObject origin)
        {
            this.origin = origin;
        }

        public PoolData(GameObject origin,float lifeTime)
        {
            this.origin = origin;
            this.lifeTime = lifeTime;
        }
    }

    public List<PoolData> pool = new List<PoolData>();

    public void Awake()
    {
        pool.Clear();
    }

    public void Pool(GameObject gameObject, int num)
    {
        for (int i = 0; i < num; i++)
        {
            PoolData tmp = new PoolData(Instantiate(gameObject));
            tmp.origin.SetActive(false);
            pool.Add(tmp);
        }
    }

    public void AutoReturnPool(GameObject gameObject,int num,float lifeTime)
    {
        for (int i=0; i<num; i++)
        {
            PoolData tmp = new PoolData(Instantiate(gameObject),lifeTime);
            tmp.origin.SetActive(false);
            pool.Add(tmp);
        }

        AutoReturnPooler autoReturnPooler = new GameObject("AutoReturnPooler").AddComponent<AutoReturnPooler>();
        autoReturnPooler.Init(pool);
    }

    public GameObject GetPool()
    {
        foreach(PoolData item in pool)
        {
            if (item.origin.activeSelf == false)
            {
                item.origin.SetActive(true);
                return item.origin;
            }
        }

        try
        {
            return pool[pool.Count - 1].origin;
        }
        catch
        {
            return null;
        }
    }

    public void ReturnPool()
    {
        foreach(PoolData item in pool)
        {
            if(item.origin.activeSelf == true)
            {
                item.origin.SetActive(false);
                break;
            }
        }
    }

    public void ReturnPool(PoolData gameObject)
    {
        foreach (PoolData item in pool)
        {
            if (item.origin.activeSelf == true && item == gameObject)
            {
                item.origin.SetActive(false);
                break;
            }
        }
    }

    public void RetureAllPool()
    {
        foreach (PoolData item in pool)
        {
            item.origin.SetActive(false);
        }
    }
}
