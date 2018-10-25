using System.Collections;
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
    private bool isSectionChange;
    public bool isSecondSection;

    private void OnDisable()
    {
        index = 0;
        isSecondSection = false;
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

        float nextStageDepth;

        if (isSecondSection)
            nextStageDepth = gameObject.transform.position.z + 60;
        else
            nextStageDepth = gameObject.transform.position.z;

        currentSection.Spawn(nextStageDepth);

        index++;

        if (index >= sectionDatas.Length)
            index = 0;

        if (index != oldIndex || !isSecondSection)
        {
            objectGenerater.OnSectionChange(sectionDatas[index]);
            isSecondSection = true;
        }
    }
}
