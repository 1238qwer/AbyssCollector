using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]private GameObject followObject;
    [SerializeField] private float latency;
    float count;
    int index;

    private List<float> followObjectTransforms = new List<float>();

    private void Start()
    {
        transform.position = new Vector3(0, 0, -10);
    }

    private void Update()
    {
        count+= Time.deltaTime;
        followObjectTransforms.Add(followObject.transform.position.y);

        if (count >= latency)
        {
            transform.position = new Vector3(0, followObjectTransforms[index], -10);
            index++;
        }
    }
}