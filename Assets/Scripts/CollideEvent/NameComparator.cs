﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NameComparator : MonoBehaviour
{
    [Serializable]
    public class TagData
    {
        [Serializable]
        public class NameEvent : UnityEvent<GameObject> { }

        public string[] names;
        public bool isMust;
        public NameEvent nameEvent;
    }

    public TagData[] nameDatas;

    public void OnEvent(GameObject gameObject)
    {
        foreach (TagData data in nameDatas)
        {
            foreach (string name in data.names)
            {
                if (gameObject.name.Contains(name))
                {
                    data.nameEvent.Invoke(gameObject);
                }
                else if (data.isMust)
                {
                    data.nameEvent.Invoke(gameObject);
                }
            }
        }
    }
}
