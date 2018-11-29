using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour {

    public class AttractionData
    {
        public GameObject guest;
        public float playTime;

        public AttractionData(GameObject guest)
        {
            this.guest = guest;
        }
    }

    public GameObject entrance;
    public GameObject exit;
    public float maxPlayTime;

    private List<AttractionData> attractionDatas = new List<AttractionData>();
    public ObjectGenerater objectGenerater;
    public GameObject[] characters;

	// Use this for initialization
	void Awake () {

		foreach(GameObject item in characters)
        {
            AttractionData tmp = new AttractionData(item);

            attractionDatas.Add(tmp);
        }
	}
	
	// Update is called once per frame
	void Update () {

        foreach (AttractionData item in attractionDatas)
        {
            if (item.guest.activeSelf == true)
            {
                item.playTime += Time.deltaTime;

                if (item.playTime >= maxPlayTime)
                {
                    item.guest.SetActive(false);
                    //objectGenerater.ManualLocationSpawn(exit.transform, guestOrigin);
                    foreach(GameObject guest in guestOrigins)
                    {
                        if (guest.activeSelf == false)
                        {
                            guest.transform.position = exit.transform.position;
                            guest.SetActive(true);
                            item.playTime = 0;

                            return;
                        }
                    }
                }
            }
        }

	}

    private List<GameObject> guestOrigins = new List<GameObject>();
   
    public void Enter(GameObject guest)
    {
        GameObject guestOrigin = guest.transform.parent.gameObject;
        guestOrigins.Add(guestOrigin);

        foreach(AttractionData item in attractionDatas)
        {
            if (item.guest.activeSelf == false)
            {
                item.guest.SetActive(true);
                guest.transform.parent.gameObject.SetActive(false);

                return;
            }          
        }
    }
}
