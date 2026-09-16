using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    public Stack<State> states { get; set; }

    private void Awake()
    {
        //Empty stack
        states = new Stack<State>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if there is an active state, if there is then invoke it
        if(GetCurrentState() != null)
        {
            GetCurrentState().ActiveAction.Invoke();
        }
    }

    public void pushState(Action active, Action onEnter)
    {
        //used to get the AI into its next state
        State state = new State(active, onEnter);
        states.Push(state);

        GetCurrentState().OnEnterExecuteAction();
    }

    private State GetCurrentState()
    {
        //gets whatever state should currently be active if states.count is more than 0
        return states.Count > 0 ? states.Peek() : null;
    }
}
