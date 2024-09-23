using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoal
{
    bool CanRun();
    float OnCalculatePrio();
    void OnTickGoal();
    void OnGoalActivated();
    void OnGoalDeactivated();
}


public class GoalBase : MonoBehaviour, IGoal
{
    protected AgentBehaviour agent;
    void Awake()
    {
        agent = GetComponent<AgentBehaviour>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        OnTickGoal();
    }

    public virtual bool CanRun()
    {
        return false;
    }
    public virtual float OnCalculatePrio()
    {
        return -1;
    }
    public virtual void OnTickGoal()
    {

    }

    public virtual void OnGoalActivated()
    {

    }

    public virtual void OnGoalDeactivated()
    {

    }
}
