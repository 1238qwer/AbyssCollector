using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SectionManager : ScriptableObject {

    public GameObject[] sections;
    public bool isRandomSection;

    private int index;

    public void NextSectionSpawn()
    {
        if (isRandomSection)
            index = Random.Range(0, sections.Length - 1);
        
        GameObject currentSection = Instantiate(sections[index]);

        index++;
        if (index >= sections.Length)
            index = 0;
    }
}
