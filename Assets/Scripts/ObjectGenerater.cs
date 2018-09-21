using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectGenerater : MonoBehaviour {

    [SerializeField] private GameObject[] generatingPos;

    float rnd;
    float ct;

    public bool isManual;

    [Serializable]
    public class ObjectData
    {
        public GameObject origin;
        public float delayTime;
        public float generatePercentage;
    }
    public ObjectData[] objectDatas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isManual)
            return;

        ct += Time.deltaTime;
        foreach(var item in objectDatas)
        {
            if (ct >= item.delayTime)
            {
                rnd = UnityEngine.Random.Range(0, 100);
                if (rnd <= item.generatePercentage)
                {
                    GameObject trap = 
                        Instantiate(item.origin, generatingPos[UnityEngine.Random.Range(0, generatingPos.Length)].transform.position, Quaternion.identity);
                    trap.transform.rotation = new Quaternion(0, 180, 0, 0);
                    ct = 0;
                }
            }
        }
    }

    public void ManualSpawn(List<CatchableGhost> catchableGhosts)
    {
        foreach(var item in catchableGhosts)
        {
            GameObject spwned = 
                Instantiate(item.gameObject, generatingPos[UnityEngine.Random.Range(0, generatingPos.Length)].transform.position, Quaternion.identity);
        }
    }
}
