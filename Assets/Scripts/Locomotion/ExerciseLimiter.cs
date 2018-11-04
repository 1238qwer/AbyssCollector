using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseLimiter : MonoBehaviour {

    private LocomotionController exerciser;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private void Awake () {
        exerciser = GetComponent<LocomotionController>();
	}
	
	void Update () {

        if (transform.localRotation.y >= 0)
        {
            if (transform.position.x <= maxX)
                exerciser.DynamicDirectionChange(new Vector3(Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }
        if (transform.localRotation.y <= 0)
        {
            if (transform.position.x >= minX)
                exerciser.DynamicDirectionChange(new Vector3(-Mathf.Abs(transform.localRotation.y) * 15, 0, 0));
            else
                exerciser.DynamicDirectionChange(new Vector3(0, 0, 0));
        }
    }
}
