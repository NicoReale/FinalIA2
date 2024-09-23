using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherGoal : GoalBase
{
    [SerializeField] int minPriority = 0;
    [SerializeField] int maxPriority = 20;
    [SerializeField] float priorityBuildRate = 1f;
    float currPriority = 0f;

    public override void OnTickGoal()
    {
        if(agent.movement.isMoving)
        {
            agent.temp -= 3 * Time.deltaTime;
        }
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
