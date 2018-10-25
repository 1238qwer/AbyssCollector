using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectGenerater : MonoBehaviour {

    [SerializeField] private GameObject[] generatingPos;
    [SerializeField] private SectionManager sectionManager;

    float rnd;
    private float ct;
    private float ct2;
    private float ct3;

    private ObjectPooler ghostPooler;
    private ObjectPooler catchablePooler;
    private ObjectPooler obstaclePooler;

    public bool isManual;

    private List<SectionManager.ObjectData> ghostDatas = new List<SectionManager.ObjectData>();
    private List<SectionManager.ObjectData> catchableGhostDatas = new List<SectionManager.ObjectData>();
    private List<SectionManager.ObjectData> obstacleDatas = new List<SectionManager.ObjectData>();

    public void OnSectionChange(SectionManager.SectionData sectionData)
    {
        ghostDatas.Clear();
        catchableGhostDatas.Clear();
        obstacleDatas.Clear();

        foreach(var item in sectionData.Ghost)
        {
            ghostDatas.Add(item);
            ghostPooler.AutoReturnPool(item.origin, 10, 5);
        }
        foreach (var item in sectionData.CatchableGhost)
        {
            catchableGhostDatas.Add(item);
            catchablePooler.AutoReturnPool(item.origin, 3, 10);
        }
        foreach (var item in sectionData.Obstacle)
        {
            obstacleDatas.Add(item);
            obstaclePooler.AutoReturnPool(item.origin, 10, 10);
        }
    }

    private void Awake()
    {
        ghostPooler = new ObjectPooler();
        catchablePooler = new ObjectPooler();
        obstaclePooler = new ObjectPooler();
        //sectionManager.NextSectionSpawn();
    }
    void Update () {

        if (isManual)
            return;

        ct += Time.deltaTime;
        foreach(var item in ghostDatas)
        {
            if (ct >= item.delay)
            {
                rnd = UnityEngine.Random.Range(0, 100);
                if (rnd <= item.percentage)
                {
                    GameObject trap = ghostPooler.GetPool();
                    trap.transform.position = generatingPos[UnityEngine.Random.Range(0, generatingPos.Length)].transform.position;
                    ct = 0;

                    Exerciser trapRig = trap.GetComponent<Exerciser>();
                    trapRig.DynamicDirectionChange(new Vector3(0, 0, -30));
                }
            }
        }


        ct2 += Time.deltaTime;
        foreach (var item in catchableGhostDatas)
        {
            if (ct2 >= item.delay)
            {
                rnd = UnityEngine.Random.Range(0, 100);
                if (rnd <= item.percentage)
                {
                    GameObject trap = catchablePooler.GetPool();
                    trap.transform.position = generatingPos[UnityEngine.Random.Range(0, generatingPos.Length)].transform.position;
                    ct2 = 0;
                }
            }
        }

        ct3 += Time.deltaTime;
        foreach (var item in obstacleDatas)
        {
            if (ct3 >= item.delay)
            {
                rnd = UnityEngine.Random.Range(0, 100);
                if (rnd <= item.percentage)
                {
                    GameObject trap =
                        Instantiate(item.origin, generatingPos[UnityEngine.Random.Range(0, generatingPos.Length)].transform.position, Quaternion.identity);
                    //trap.transform.rotation = new Quaternion(0, 180, 0, 0);
                    ct3 = 0;
                }
            }
        }
    }

    public void ManualSpawn(List<CatchableGhost> catchableGhosts)
    {
        foreach(var item in catchableGhosts)
        {
            GameObject spwned = 
                Instantiate(item.gameObject, new Vector3(UnityEngine.Random.Range(-1.0f,20.0f),0,UnityEngine.Random.Range(-13.0f,0f)), Quaternion.identity);
        }
    }
}
