using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NameComparator : MonoBehaviour
{
    public bool getParentName;

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
        string gameObjectname = gameObject.name;

        if (getParentName)
            gameObjectname = gameObject.transform.root.name;

        foreach (TagData data in nameDatas)
        {
            if (data.isMust)
            {
                foreach (string name in data.names)
                {
                    if (gameObjectname.Contains(name))
                    {
                        return;
                    }
                }

                data.nameEvent.Invoke(gameObject);
                return;
            }

            foreach (string name in data.names)
            {

                if (gameObjectname.Contains(name))
                {
                    data.nameEvent.Invoke(gameObject);
                }
            }
        }
    }
}
