using System;
using UnityEngine;

public class State
{
    public Action ActiveAction;
    public Action OnEnterAction;

    public State(Action active, Action OnEnter)
    {
        ActiveAction = active;
        OnEnterAction = OnEnter;
    }

    public void ExecuteAction()
    {
        //if there is no active action that we can go to then dont invoke
        if(ActiveAction != null)
        {
            ActiveAction.Invoke();
        }
    }

    public void OnEnterExecuteAction()
    {
        //Same as above if there is no OnEnter state we can go then dont invoke
        if(OnEnterAction != null)
        {
            OnEnterAction.Invoke();
        }
    }

}
