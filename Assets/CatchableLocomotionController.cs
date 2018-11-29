using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableLocomotionController : LocomotionController
{
    private Transform parents;
    public Transform Paraents
    {
        get
        {
            return parents;
        }
    }

    private void Awake()
    {
       parents = transform.parent;
    }

    void Update()
    {
        if (!isStop)
        {
            parents.transform.position += direction * Time.deltaTime * speed;
        }
    }

    public override void Turn()
    {
        parents.Rotate(new Vector3(0, Random.Range(90, 180), 0));
        DynamicDirectionChange(parents.forward);
    }
}
