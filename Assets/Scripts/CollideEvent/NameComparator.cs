using System.Collections;
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
            if (data.isMust)
            {
                foreach (string name in data.names)
                {
                    if (gameObject.name.Contains(name))
                    {
                        return;
                    }
                }

                data.nameEvent.Invoke(gameObject);
                return;
            }

            foreach (string name in data.names)
            {

                if (gameObject.name.Contains(name))
                {
                    data.nameEvent.Invoke(gameObject);
                }
            }
        }
    }
}
