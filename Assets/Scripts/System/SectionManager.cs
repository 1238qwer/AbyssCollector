using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class SectionManager : ScriptableObject {

    private ObjectGenerater objectGenerater;

    [Serializable]
    public class SectionData
    {
        public Section section;
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

        if (!objectGenerater)
            objectGenerater = new GameObject("AdvancedGenerator").AddComponent<ObjectGenerater>();

        if (isRandomSection)
            index = UnityEngine.Random.Range(0, sectionDatas.Length - 1);           

        Section currentSection = sectionDatas[index].section;

        currentSection.Spawn(objectGenerater);

        index++;

        if (index >= sectionDatas.Length)
            index = 0;
    }

    public void SpawnerActiveHandle(bool active)
    {
        objectGenerater.ActiveHandle(active);
    }
}
