using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviours
{
    float maxSteering = 1f;

    public float speed { set { speed = value; } }

    agentMovementBehaviour agent;
    Transform transform;
    Vector3 _velocity;
    public Vector3 velocity { get { return _velocity; } }

    public MovementBehaviours Initialize(agentMovementBehaviour agent, Transform transform, float maxSteering)
    {
        this.transform = transform;
        this.maxSteering = maxSteering;
        this.agent = agent;
        return this;
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position);
        var steering = CalculateSteering(desired, agent.speed);
        ApplyForce(steering, agent.speed);
        return steering;
    }



    Vector3 CalculateSteering(Vector3 desired, float speed)
    {
        desired = desired.normalized * speed;

        Vector3 steering = desired - _velocity;

        steering = Vector3.ClampMagnitude(steering, maxSteering / 100);

        return steering;
    }


    public void ApplyForce(Vector3 force, float speed)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, speed);
        _velocity.z = 0;
    }
}
