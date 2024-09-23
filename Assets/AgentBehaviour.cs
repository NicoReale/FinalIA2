using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    [SerializeField] float _temp = Data.basicAgent.MaxTemp;
    [SerializeField] float _food = 0;
    [SerializeField] float _wood = 0;
    [SerializeField] NavPoint _currentPoint;
    [SerializeField] agentMovementBehaviour _movement;

    public float temp { get { return _temp; } set { _temp = value; } }
    public NavPoint currentPoint { get { return _currentPoint; } }
    public agentMovementBehaviour movement { get { return _movement; } }


    StateMachine fsm;
    IState moveState;

    private void Start()
    {
        fsm = new StateMachine();
        _currentPoint = NavPointsMap.instance.GetClosestNavPoint(transform.position);
        _movement = new agentMovementBehaviour().Initialize(this, transform);

        moveState = new Move(this);

        fsm.AddState(moveState, "move");
        fsm.ChangeState("move");
    }

    private void Update()
    {

        fsm.Update();
        
        _currentPoint = NavPointsMap.instance.GetClosestNavPoint(transform.position);
    }
}
