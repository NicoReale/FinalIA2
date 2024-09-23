using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class agentMovementBehaviour
{
    [SerializeField] NavPoint _targetNode;
    [SerializeField] float _speed;

    public bool isMoving = false;
    AgentBehaviour agent;
    public float speed { get { return (agent.temp / Data.basicAgent.MaxTemp) * (Data.basicAgent.MaxSpeed / 5); } }
    public NavPoint targetNode { get { return _targetNode; } }

    MovementBehaviours movement;
    Transform transform;

    public agentMovementBehaviour Initialize(AgentBehaviour agent, Transform transform)
    {
        this.transform = transform;
        this.agent = agent;
        movement = new MovementBehaviours().Initialize(this, transform, Data.basicAgent.MaxSteering);

        if (NavPointsMap.instance != null)
        {
            NewRandomTarget();
        }
        else
        {
            Debug.LogError("NavPointsMap.instance is null.");
        }
        return this;
    }

    public void Move(List<NavPoint> points)
    {
        isMoving = true;

        movement.ApplyForce(movement.Seek(points[0].gameObject.transform.position), speed);

        transform.position += movement.velocity * Time.deltaTime;

        float angle = Mathf.Atan2(movement.velocity.y, movement.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Vector3.Distance(transform.position, points[0].gameObject.transform.position) <= 1f)
        {
            points.RemoveAt(0);
            if(points.Count >= 0)
            {
                isMoving = false;
            }
        }
    }   

    public void NewRandomTarget()
    {
        _targetNode = NavPointsMap.instance.GetRandomPoint();
    }

}