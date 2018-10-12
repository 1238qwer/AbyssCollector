using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TagComparator : MonoBehaviour{

    [Serializable]
    public class TagData
    {
        [Serializable]
        public class TagEvent : UnityEvent<GameObject> { }

        public string[] tags;
        public bool isMust;
        public TagEvent tagEvent;         
    }

    public TagData[] tagDatas;

    public void OnEvent(GameObject gameObject)
    {
        foreach(TagData data in tagDatas)
        {
            if (data.isMust)
            {
                foreach (string tag in data.tags)
                {
                    if (gameObject.name.Contains(tag))
                    {
                        return;
                    }
                }

                data.tagEvent.Invoke(gameObject);
                return;
            }

            foreach (string tag in data.tags)
            {
                if (tag == gameObject.tag)
                {
                    data.tagEvent.Invoke(gameObject);
                }
            }
        }
    }
}
