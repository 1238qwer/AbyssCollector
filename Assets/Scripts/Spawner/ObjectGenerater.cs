using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectGenerater : MonoBehaviour {

    [Serializable]
    public class GenerateData
    {
        public Section.ObjectData data;
        public float currentTime;

        public GenerateData(Section.ObjectData objectData)
        {
            this.data = objectData;
        }
    }

    public List<GenerateData> generateDatas = new List<GenerateData>();

    private Vector3 min;
    private Vector3 max;

    float rnd;

    private ObjectPooler ghostPooler;
    public ObjectPooler catchablePooler;
    private ObjectPooler obstaclePooler;

    public bool active;

    public void Init(Section.SpawnData spawnData,Vector3 minSpawnPos,Vector3 maxSpawnPos)
    {
        ghostPooler = new ObjectPooler();
        catchablePooler = new ObjectPooler();
        obstaclePooler = new ObjectPooler();

        this.min = minSpawnPos;
        this.max = maxSpawnPos;

        generateDatas.Clear();

        foreach (var item in spawnData.ghost)
        {
            GenerateData tmp = new GenerateData(item);
            generateDatas.Add(tmp);
            ghostPooler.Pool(item.origin, 20);
        }
        foreach (var item in spawnData.catchable)
        {
            GenerateData tmp = new GenerateData(item);
            generateDatas.Add(tmp);
            catchablePooler.Pool(item.origin, 10);
        }
        foreach (var item in spawnData.obstacle)
        {
            GenerateData tmp = new GenerateData(item);
            generateDatas.Add(tmp);
            obstaclePooler.Pool(item.origin, 10);
        }
    }

    void Update () {
        if (active)
            Spawn();
    }

    public void ActiveHandle(bool active)
    {
        this.active = active;
    }

    public void Spawn()
    {
        foreach (var item in generateDatas)
        {
            item.currentTime += Time.deltaTime;

            if (item.currentTime >= item.data.delay)
            {
                rnd = UnityEngine.Random.Range(0, 100);
                if (rnd <= item.data.percentage)
                {
                    if (item.data.origin.tag == "Ghost")
                    {
                        GameObject trap = ghostPooler.GetPool();
                        trap.transform.position = new Vector3(UnityEngine.Random.Range(min.x, max.x), 0, max.z);
                    }
                    else if (item.data.origin.tag == "Obstacle")
                    {
                        GameObject trap = obstaclePooler.GetPool();
                        trap.transform.position = new Vector3(UnityEngine.Random.Range(min.x, max.x), 0, max.z);
                    }
                    else
                    {
                        GameObject trap = catchablePooler.GetPool(item.data.origin.name);
                        trap.transform.position = new Vector3(UnityEngine.Random.Range(min.x, max.x), 0, max.z);
                    }
                    item.currentTime = 0;
                }
            }
        }
    }

    public void ManualSpawn(List<GameObject> catchableGhosts)
    {
        foreach(var item in catchableGhosts)
        {
            GameObject spwned = 
                Instantiate(item, new Vector3(UnityEngine.Random.Range(-1.0f,20.0f),0,UnityEngine.Random.Range(-13.0f,0f)), Quaternion.identity);
        }
    }

    public void ManualLocationSpawn(Transform location,GameObject gameObject)
    {
        GameObject spwned = 
                Instantiate(gameObject, new Vector3(UnityEngine.Random.Range(-1.0f,20.0f),0,UnityEngine.Random.Range(-13.0f,0f)), Quaternion.identity);
        
    }
}
