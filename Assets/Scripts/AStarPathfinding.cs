using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AStarPathfinding
{
    public List<NavPoint> ConstructAStar(NavPoint startingNode, NavPoint goalNode)
    {
        if (startingNode == null || goalNode == null) return null;

        PriorityQueueBasicNode frontier = new PriorityQueueBasicNode();
        frontier.Put(startingNode, 0);

        Dictionary<NavPoint, NavPoint> cameFrom = new Dictionary<NavPoint, NavPoint>();
        cameFrom.Add(startingNode, null);

        Dictionary<NavPoint, float> costSoFar = new Dictionary<NavPoint, float>();
        costSoFar.Add(startingNode, 0);

        while (frontier.Count > 0)
        {
            NavPoint current = frontier.Get();

            if (current == goalNode)
            {
                List<NavPoint> path = new List<NavPoint>();
                NavPoint nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                path.Reverse();
                return path;
            }

            foreach (var next in current.GetNeighbours())
            {
                if (next.blocked) continue;
                float dist = Vector3.Distance(goalNode.transform.position, next.transform.position);
                float newCost = costSoFar[current] + next.cost;
                if (!cameFrom.ContainsKey(next))
                {
                    float priority = newCost + dist * dist;
                    frontier.Put(next, priority);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else
                {
                    if (newCost < costSoFar[next])
                    {
                        float priority = newCost + dist * dist;

                        frontier.Put(next, priority);
                        cameFrom[next] = current;
                        costSoFar[next] = newCost;
                    }
                }
            }
        }

        return null;
    }
}
