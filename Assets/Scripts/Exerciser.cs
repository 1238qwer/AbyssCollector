using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerciser : MonoBehaviour {

    [SerializeField]
    public Vector3 direction;
    public float speed;
    private bool isStop;

	void Update () {
        //transform.Translate(direction * Time.deltaTime);
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
}
