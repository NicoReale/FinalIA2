using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    Dictionary<string, IState> states = new Dictionary<string, IState>();
    IState currentState;
    public void Update()
    {
        if(currentState != null)
            currentState.Execute();
    }

    public void AddState(IState state, string name)
    {
        if (states.ContainsValue(state))
        {
            Debug.Log($"{name} already exists as {state.Name}");
            return;
        }

        state.Name = name;
        states.Add(state.Name, state);
        Debug.Log($"{name} added as {state.Name}");
    }

    public void RemoveState(string name)
    {
        if (!states.ContainsKey(name)) 
        {
            Debug.Log($"{name} does not exist");
            return;
        }
        states.Remove(name);
    }

    public void ChangeState(string name)
    {
        if(!states.ContainsKey(name))
        {
            Debug.Log("State does not exists or no current state is assigned");
            return;
        }
        if(currentState != null)
            currentState.Exit();

        currentState = states[name];
        currentState.Enter();
    }
}
