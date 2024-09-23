using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Move : IState
{
    private string name;
    public string Name { get => name; set => name = value; }

    AgentBehaviour agentBehaviour;

    AStarPathfinding _pf;
    [SerializeField] List<NavPoint> _movementPoints = new List<NavPoint>();

    public Move(AgentBehaviour agentBehaviour)
    {
        this.agentBehaviour = agentBehaviour;
        _pf = new AStarPathfinding();
    }

    public void Enter()
    {
        Debug.Log("entered Moving");
        agentBehaviour.movement.NewRandomTarget();
        _movementPoints = _pf.ConstructAStar(agentBehaviour.currentPoint, agentBehaviour.movement.targetNode);
        //calculate path?
    }

    public void Execute()
    {
        if (_movementPoints.Count > 0)
        {
            agentBehaviour.movement.Move(_movementPoints);
        }
        else
        {
            /*agentBehaviour.movement.NewRandomTarget();
            _movementPoints = _pf.ConstructAStar(agentBehaviour.currentPoint, agentBehaviour.movement.targetNode);*/
        }
    }

    public void Exit()
    {
        //empty path and stop movement
    }
}
