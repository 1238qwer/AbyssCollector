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

    public float stopElapseTime;
    public void Stop(float time)
    {
        isStop = true;
        StartCoroutine(StopTimer(time));     
    }

    private IEnumerator StopTimer(float time)
    {
        yield return new WaitForSeconds(2.0f);
        Move();
        stopElapseTime = 0;
    }

    public void Turn()
    {
        transform.Rotate(new Vector3(0, Random.Range(90, 180), 0));
    }

    public void Follow(GameObject gameObject)
    {
        Vector3 vec;
        vec = transform.position - gameObject.transform.position;

        DynamicDirectionChange(vec);
    }

    private float followElapseTime;
    public void Follow(GameObject gameObject,float time)
    {
        Vector3 originVec;
        originVec = direction;
        Vector3 vec;
        vec = transform.position - gameObject.transform.position;

        DynamicDirectionChange(vec);

        followElapseTime += Time.deltaTime;
        if (followElapseTime >= time)
        {
            DynamicDirectionChange(originVec);
            followElapseTime = 0;
        }
    }
}
