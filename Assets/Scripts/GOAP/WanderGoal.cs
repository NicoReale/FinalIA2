using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderGoal : GoalBase
{
    [SerializeField] int minPriority = 0;
    [SerializeField] int maxPriority = 20;
    [SerializeField] float priorityBuildRate = 5f;
    [SerializeField] float priorityDecayRate = 3f;
    float currPriority = 0f;

    public override void OnTickGoal()
    {
        if (agent.movement.isMoving)
        {
            currPriority -= priorityDecayRate * Time.deltaTime;           
        }
        else
        {
            currPriority += priorityBuildRate * Time.deltaTime;
        }
        Debug.Log(currPriority);
    }

    public override void OnGoalActivated()
    {
        currPriority = maxPriority;
    }
    public override bool CanRun()
    {
        return true;
    }
    public override float OnCalculatePrio()
    {
        return Mathf.FloorToInt(currPriority);
    }
}
