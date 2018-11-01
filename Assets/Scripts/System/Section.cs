using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Section : ScriptableObject {

    [Serializable]
    public class ObjectData
    {
        public GameObject origin;
        public float delay;
        public float percentage;
    }
   
    [Serializable]
    public class SpawnData
    {
        public ObjectData[] ghost;
        public ObjectData[] obstacle;
        public ObjectData[] catchable;
    }

    [Header("[ SpawnData ]")]
    public SpawnData spawnData;

    [Header("[ SectionData ]")]
    public GameObject sectionHead;
    public GameObject[] sectionBody;
    public GameObject sectionTail;

    [Header("[ Optional ]")]
    public float secondSectionDepth;
    public Vector3 minSpawnPos;
    public Vector3 maxSpawnPos;

    [HideInInspector]
    public bool alreadySpawned;

    private float depth;
    private float testFloat;
    private float currentFloat;

    private GameObject head;
    private List<GameObject> bodies = new List<GameObject>();
    private GameObject body;
    private GameObject tail;

    private void OnEnable()
    {
        Reset();
    }

    private void Reset()
    {
        testFloat = 30;
        depth = 0; //리셋함수로
        alreadySpawned = false;

        head = null;
        body = null;
        tail = null;
        bodies.Clear();
    }

    public void Spawn(ObjectGenerater objectGenerater)
    {
        depth = 0;

        alreadySpawned = head ? true : false;

        if (alreadySpawned)
        {
            SectionTranslate();
        }
        else
        {
            objectGenerater.Init(spawnData, minSpawnPos, maxSpawnPos);
            SectionSpawn();
        }      
    }

    private void SectionTranslate()
    {
        head.transform.position = new Vector3(0, -1, secondSectionDepth);

        currentFloat = head.transform.position.z;

        for (int i = 0; i < sectionBody.Length; i++)
        {
            depth += testFloat;
            bodies[i].transform.position = new Vector3(0, -1, currentFloat + depth);
        }

        depth += testFloat;

        //tail.transform.position = new Vector3(0, -1, currentFloat + depth);
        tail =
            Instantiate(sectionTail, new Vector3(0, -1, currentFloat + depth), Quaternion.identity);
    }

    private void SectionSpawn()
    {
        head = Instantiate(sectionHead, new Vector3(0, -1, 0), Quaternion.identity);

        currentFloat = head.transform.position.z;

        for (int i = 0; i < sectionBody.Length; i++)
        {
            depth += testFloat;

            body = Instantiate(sectionBody[i], new Vector3(0, -1, currentFloat + depth), Quaternion.identity);
            bodies.Add(body);
        }

        depth += testFloat;

        //if (!tail)
        tail =
        Instantiate(sectionTail, new Vector3(0, -1, currentFloat + depth), Quaternion.identity);
    }
}
