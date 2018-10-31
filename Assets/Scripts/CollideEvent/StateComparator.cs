using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class StateComparator : MonoBehaviour {

    private StateManager stateManager;
    private string currentState;

    [Serializable]
    public class StateData
    {
        [Serializable]
        public class StateEvent : UnityEvent<GameObject> { }

        public string[] compareState;
        public StateEvent trueEvent;
        public StateEvent falseEvent;
    }

    public StateData[] stateDatas;

    private void Awake()
    {
        stateManager = GetComponent<StateManager>();
    }

    public void OnEvent(GameObject gameObject)
    {
        currentState = stateManager.State;

        foreach (StateData data in stateDatas)
        {
            foreach(string state in data.compareState)
            {
                if (currentState == state)
                {
                    data.trueEvent.Invoke(gameObject);
                    return;
                }

                data.falseEvent.Invoke(gameObject);
            }
        }
    }
}
