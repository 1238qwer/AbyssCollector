using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class StateComparator : MonoBehaviour {

    private string currentState;

    [SerializeField] private UnityEvent trueEvents;
    [SerializeField] private UnityEvent falseEvents;

    public void SetState(string state)
    {
        currentState = state;
    }

    public void OnEvent(string state)
    {
        if (currentState == state)
            trueEvents.Invoke();
        else
            falseEvents.Invoke();
    }
}
