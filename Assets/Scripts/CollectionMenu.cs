using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CollectionMenu : MonoBehaviour {

    [SerializeField] private Vector3[] CollectionTransforms;

    [SerializeField] private Inventory inventory;

    public List<Fish> collections = new List<Fish>();
    public Image image;

    public class CollectionData
    {
        public string id;
        public GameObject origin;
        public string discription;
    }

    [SerializeField]private List<CollectionData> collectionDatas = new List<CollectionData>();
	// Use this for initialization
	void Awake () {
        Locate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    float index = 1.3f;
    private void Locate()
    {
        collections = inventory.GetAll();

        for (int i = 0; i < collections.Count; i++)
        {
          
            Image currentImage = Instantiate(image, new Vector3(0,-0.7f-index,0), Quaternion.identity);
            currentImage.transform.SetParent(transform);
            currentImage.transform.localScale = new Vector3(1, 1, 1);

            CollectionButton currentCollectionButton = currentImage.GetComponent<CollectionButton>();
            currentCollectionButton.Init(collections[i], "작은 물고기입니다.",inventory);

            Debug.Log(collections[i]);
            Image currentIcon = Instantiate(
                Resources.Load<Image>("Icons/" + collections[i].name) as Image, 
                new Vector3(currentImage.transform.position.x - 2f, currentImage.transform.position.y, currentImage.transform.position.z), 
                Quaternion.identity
                );

            currentIcon.transform.SetParent(currentImage.transform);
            currentIcon.transform.localScale = new Vector3(1, 1, 1);
            index++;
        }

    }

}
