using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerciser : MonoBehaviour {

    [SerializeField]
    public Vector3 direction;
    public float speed;
    private bool isStop;

	void Update () {
        if (!isStop)
            transform.position += direction * Time.deltaTime * speed;
	}

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void DynamicDirectionChange(Vector3 direction)
    {
        this.direction = direction;
    }

    public void DynamicDirectionChange(Vector3 direction,float minimun,float maximum)
    {
        if (gameObject.transform.position.x >= maximum)
        {
            direction = Vector3.zero;
            return;
        }

        if (gameObject.transform.position.x <= minimun)
        {
            direction = Vector3.zero;
            return;
        }

        this.direction = direction;
    }

    public void DynamicDirectionFlip()
    {
        this.direction = -this.direction;
    }

    public void Stop()
    {
        isStop = true;
    }

    public void Move()
    {
        isStop = false;
    }

    public void Stop(float time)
    {
        isStop = true;
        StartCoroutine(StopTimer(time));     
    }

    private IEnumerator StopTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Move();
    }

    public void Turn()
    {
        transform.Rotate(new Vector3(0, Random.Range(90, 180), 0));
        DynamicDirectionChange(transform.forward);
    }

    private float followTime;
    public void Follow(GameObject gameObject)
    {
        StartCoroutine(FollowObject(gameObject));
    }

    private IEnumerator FollowObject(GameObject gameObject)
    {
        Vector3 vec;
        vec = gameObject.transform.position - transform.position;

        transform.LookAt(gameObject.transform);
        DynamicDirectionChange(vec);

        yield return null;

        StartCoroutine(FollowObject(gameObject));
    }

    public void FollowTimeSet(float time)
    {
        followTime = time;

        StartCoroutine(FollowTimer(time));
    }

    private IEnumerator FollowTimer(float time)
    {
        yield return new WaitForSeconds(time);

        StopAllCoroutines();
        DynamicDirectionChange(transform.forward);
    }
}
