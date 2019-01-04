using UnityEngine;
using UnityEngine.Events;
using System;

public class ColliderEventGenerator : MonoBehaviour {

    [Serializable]
    public class ColliderEvent : UnityEvent<GameObject> { };

    public ColliderEvent onTriggerEnter;
    public ColliderEvent onTriggerStay;
    public ColliderEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other.gameObject);
    }
}
