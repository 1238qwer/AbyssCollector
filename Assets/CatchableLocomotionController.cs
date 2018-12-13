using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchableLocomotionController : LocomotionController
{
    private Transform parents;
    private NavMeshAgent navMeshAgent;
    private Vector3 desination;

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
        if (gameObject.scene.name == "Room")
        {
            if (!isStop)
            {
                navMeshAgent.SetDestination(desination);
                //parents.transform.position += direction * Time.deltaTime * speed;
            }
        }
        else
        {
            parents.transform.position += direction * Time.deltaTime * speed;
        }
    }

    public override void Turn()
    {
        parents.Rotate(new Vector3(0, Random.Range(90, 180), 0));
        DynamicDirectionChange(parents.forward);
    }

    public void TurnTo(GameObject gameObject)
    {
        navMeshAgent.SetDestination(gameObject.transform.position);
    }

    public void Goto(GameObject gameObject)
    {
        //StartCoroutine(GotoObject(gameObject));

        //Debug.Log(gameObject + "로 가는중");
        desination = gameObject.transform.position;
        navMeshAgent.isStopped = false;
    }

    public void Stop()
    {
        //StartCoroutine(GotoObject(gameObject));

        //Debug.Log(gameObject + "로 가는중");
        navMeshAgent.isStopped = true;
    }

    float distance;
    private IEnumerator GotoObject(GameObject gameObject)
    {
        //Debug.Log(gameObject + "로 가는중");
        navMeshAgent.SetDestination(gameObject.transform.position);

        yield return null;

        distance = Vector3.Distance(parents.transform.position, gameObject.transform.position);

        if (distance <= 0.5f)
            yield break;

        StartCoroutine(GotoObject(gameObject));
    }
}
