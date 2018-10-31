using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Section : ScriptableObject {

    public GameObject sectionHead;
    public GameObject[] sectionBody;
    public GameObject sectionTail;
    public float secondSectionDepth;
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
        testFloat = 30;
        depth = 0; //리셋함수로
        alreadySpawned = false;

        head = null;
        body = null;
        tail = null;
    }

    public void Spawn()
    {
        depth = 0;

        if (!head)
        {
            head = Instantiate(sectionHead, new Vector3(0, -1, 0), Quaternion.identity);
            alreadySpawned = true;
        }
        else
            head.transform.position = new Vector3(0, -1, secondSectionDepth);

        currentFloat = head.transform.position.z;

        for (int i = 0; i < sectionBody.Length; i++)
        {
            depth += testFloat;

            if (!bodies[i])
            {
                body = Instantiate(sectionBody[i], new Vector3(0, -1, currentFloat + depth), Quaternion.identity);
                bodies[i] = body;
            }

            bodies[i].transform.position = new Vector3(0, -1, currentFloat + depth);
        }

        depth += testFloat;

        //if (!tail)
        tail =
        Instantiate(sectionTail, new Vector3(0, -1, currentFloat + depth), Quaternion.identity);

        tail.transform.position = new Vector3(0, -1, currentFloat + depth);
    }
}
