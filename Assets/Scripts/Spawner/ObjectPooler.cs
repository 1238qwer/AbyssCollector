using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour{

    private GameObject poolWrapper;

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

    public void WrapperInit(string name)
    {
        if (!poolWrapper)
            poolWrapper = new GameObject(name + ".poolWrapper");
    }

    public void Pool(GameObject gameObject, int num)
    {
        WrapperInit(gameObject.name);

        for (int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(gameObject);

            obj.transform.parent = poolWrapper.transform;

            PoolData tmp = new PoolData(obj);
            tmp.origin.SetActive(false);
            pool.Add(tmp);
        }
    }

    public void AutoReturnPool(GameObject gameObject,int num,float lifeTime)
    {
        WrapperInit(gameObject.name);

        for (int i=0; i<num; i++)
        {
            GameObject obj = Instantiate(gameObject);

            obj.transform.parent = poolWrapper.transform;

            PoolData tmp = new PoolData(obj, lifeTime);
            tmp.origin.SetActive(false);
            pool.Add(tmp);
        }
      
        GameObject autoReturnPoolerObj = GameObject.Find("AutoReturnPooler");
        AutoReturnPooler autoReturnPooler = null;

        if (!autoReturnPoolerObj)
            autoReturnPooler = new GameObject("AutoReturnPooler").AddComponent<AutoReturnPooler>();
        else
            autoReturnPooler = autoReturnPoolerObj.GetComponent<AutoReturnPooler>();

        autoReturnPooler.Add(pool);
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

        try{return pool[pool.Count - 1].origin;}

        catch{return null;}
    }

    public GameObject GetPool(string name)
    {
        foreach (PoolData item in pool)
        {
            if (item.origin.activeSelf == false && item.origin.name.Contains(name))
            {
                
                item.origin.SetActive(true);
                return item.origin;
            }
        }

        try { return pool[pool.Count - 1].origin; }

        catch { return null; }
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

    public void ReturnAllPool()
    {
        foreach (PoolData item in pool)
        {
            item.origin.SetActive(false);
        }
    }
}
