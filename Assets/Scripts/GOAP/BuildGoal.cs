using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class BuildGoal : GoalBase
{
    [SerializeField] int Priority = 30;
    public override void OnTickGoal()
    {
        
    }

    public override void OnGoalActivated()
    {
        
    }
    public override void OnGoalDeactivated()
    {
        
    }

    public override float OnCalculatePrio()
    {
        if (Data.CurrentWorldData.hasFirepit)
        {
            return 0;
        }
        return -1;
    }
    public override bool CanRun()
    {
        if(Data.CurrentWorldData.hasFirepit)
        {
            return false;
        }
        return true;
    }
}
