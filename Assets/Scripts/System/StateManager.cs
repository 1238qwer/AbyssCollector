using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    [SerializeField] private string state;
    public string State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }
}
