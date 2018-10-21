using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Section : ScriptableObject {

    public GameObject sectionHead;
    public GameObject[] sectionBody;
    public GameObject sectionTail;

    private float depth;

    private float testFloat;

    private void OnEnable()
    {
        testFloat = 30;
        depth = 0;
    }

    public void Spawn()
    {
        GameObject currentSection = Instantiate(sectionHead,new Vector3(0,0,0),Quaternion.identity);

        foreach (GameObject item in sectionBody)
        {
            depth += testFloat;

            currentSection = Instantiate(item, new Vector3(0, 0, 0 + depth),Quaternion.identity);          
        }

        depth += testFloat;

        currentSection = 
            Instantiate(sectionTail,new Vector3(0, 0, 0 + depth),Quaternion.identity);
    }
}
