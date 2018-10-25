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
    private float currentFloat;

    private void OnEnable()
    {
        testFloat = 30;
        depth = 0; //리셋함수로
    }

    public void Spawn(float nextStageDepth)
    {
        depth = 0;
        GameObject currentSection = Instantiate(sectionHead,new Vector3(0,-1, nextStageDepth),Quaternion.identity);

        currentFloat = currentSection.transform.position.z;

        foreach (GameObject item in sectionBody)
        {
            depth += testFloat;

            currentSection = Instantiate(item, new Vector3(0 , -1, currentFloat + depth),Quaternion.identity);          
        }

        //depth += testFloat;

        currentSection = 
            Instantiate(sectionTail,new Vector3(0,-1, currentFloat + depth),Quaternion.identity);
    }
}
