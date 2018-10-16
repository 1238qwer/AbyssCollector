using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Section : ScriptableObject {

    public GameObject sectionHead;
    public GameObject[] sectionBody;
    public GameObject sectionTail;

    private float depth;

    private void OnEnable()
    {
        depth = 0;
    }

    public void Spawn()
    {
        GameObject currentSection = Instantiate(sectionHead);

        foreach (GameObject item in sectionBody)
        {
            currentSection = Instantiate(item);
        }

        currentSection = 
            Instantiate(sectionTail);
    }
}
