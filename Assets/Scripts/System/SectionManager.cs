﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class SectionManager : ScriptableObject {

    private ObjectGenerater objectGenerater;

    [Serializable]
    public class ObjectData
    {
        public GameObject origin;
        public float delay;
        public float percentage;
    }

    [Serializable]
    public class SectionData
    {
        public Section section;
        public ObjectData[] Ghost;
        public ObjectData[] Obstacle;
        public ObjectData[] CatchableGhost;
    }

    public SectionData[] sectionDatas;
    public bool isRandomSection;

    private int index;

    private void OnDisable()
    {
        index = 0;
    }

    public void NextSectionSpawn(GameObject gameObject)
    {
        int oldIndex = index;

        objectGenerater = GameObject.Find("Generator").GetComponent<ObjectGenerater>();    

        if (isRandomSection)
        {
            index = UnityEngine.Random.Range(0, sectionDatas.Length - 1);           
        }

        Section currentSection = sectionDatas[index].section;

        if (!currentSection.alreadySpawned)
        {
            objectGenerater.OnSectionChange(sectionDatas[index]);
        }

        currentSection.Spawn();

        index++;

        if (index >= sectionDatas.Length)
            index = 0;
    }
}
