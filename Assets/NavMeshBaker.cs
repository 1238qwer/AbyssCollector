using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour {

    private NavMeshSurface navMeshSurface;

    void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
    }
	// Use this for initialization
	void Start () {

        navMeshSurface.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
