using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attraction : MonoBehaviour {

    [Serializable]
    public class SeatData
    {
        public GameObject guest;
        public GameObject guestOrigin;
        public float playTime;
        public bool isSeat;
    }

    public GameObject entrance;
    public GameObject exit;
    public float maxPlayTime;

    public int seatNum;
    //private List<SeatData> attractionDatas = new List<SeatData>();
    public SeatData[] seatDatas;
    public ObjectGenerater objectGenerater;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {

        foreach (var item in seatDatas)
        {
            if (item != null && item.isSeat == true )
            {
                item.playTime += Time.deltaTime;

                if (item.playTime >= maxPlayTime)
                {
                    item.guest.SetActive(false);
                    item.guestOrigin.SetActive(true);
                    item.guestOrigin.transform.position = exit.transform.position;
                    item.isSeat = false;

                    item.playTime = 0;
                    //objectGenerater.ManualLocationSpawn(exit.transform, guestOrigin);
                    //foreach(GameObject guest in guestOrigins)
                    //{
                    //    if (guest.activeSelf == false)
                    //    {
                    //        guest.transform.position = exit.transform.position;
                    //        guest.SetActive(true);
                    //        item.playTime = 0;

                    //        return;
                    //    }
                    //}
                }
            }
        }
    }

    public void Exit()
    {
       
    }

    [Serializable]
    public class GuestOrigin
    {
        public GameObject[] origin;
    }

    public List<GuestOrigin> guestOrigins = new List<GuestOrigin>();
    
    public void Enter(GameObject guest)
    {
        CatchableGhost guestGhost = guest.GetComponent<CatchableGhost>();

        foreach (var item in guestOrigins)
        {
            if (item.origin[0].name.Contains(guestGhost.id))
            {
                Debug.Log("일치");
                for(int i=0; i<seatDatas.Length; i++)
                {
                    Debug.Log(seatDatas[i]);
                    if (seatDatas[i].isSeat == false)
                    {
                        seatDatas[i].guest = item.origin[i];
                        seatDatas[i].guestOrigin = guest.transform.parent.gameObject;
                        seatDatas[i].guestOrigin.SetActive(false);
                        seatDatas[i].isSeat = true;

                        item.origin[i].SetActive(true);
                        Debug.Log("작동");

                        return;
                    }
                }
                return;
            }
            else
                Debug.Log("불일치");
        }

    }
}
