using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableDisapearer : Disappearer
{
    Transform parents;

    private void Awake()
    {
        parents = transform.parent;
    }
    void Update()
    {
        if (Deactivate)
        {
            return;
        }

        currentTime += Time.deltaTime;
        if (currentTime >= lifeTime)
        {
            parents.gameObject.SetActive(false);
            currentTime = 0;
        }
    }
}
