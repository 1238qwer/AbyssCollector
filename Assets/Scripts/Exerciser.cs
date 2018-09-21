using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerciser : MonoBehaviour {

    [SerializeField]
    public Vector3 direction;
    public float speed;

	void Update () {
        //transform.Translate(direction * Time.deltaTime);
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

    public void DynamicDirectionFlip()
    {
        this.direction = -this.direction;
    }
}
