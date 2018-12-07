using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchableLocomotionController : LocomotionController
{
    private Transform parents;
    private NavMeshAgent navMeshAgent;

    public Transform Paraents
    {
        get
        {
            return parents;
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
       parents = transform.parent;
    }

    void Update()
    {
        if (!isStop)
        {
            navMeshAgent.SetDestination(direction * Time.deltaTime * speed);
            //parents.transform.position += direction * Time.deltaTime * speed;
        }
    }

    public override void Turn()
    {
        parents.Rotate(new Vector3(0, Random.Range(90, 180), 0));
        DynamicDirectionChange(parents.forward);
    }

    public void Goto(GameObject gameObject)
    {
        StartCoroutine(GotoObject(gameObject));
    }

    private IEnumerator GotoObject(GameObject gameObject)
    {
        Debug.Log(parents.name + "카페가는중");
        navMeshAgent.SetDestination(gameObject.transform.position);

        yield return null;

        StartCoroutine(GotoObject(gameObject));
    }
}
