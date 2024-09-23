using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PriorityQueueBasicNode
{
    Dictionary<NavPoint, float> _allNodes = new Dictionary<NavPoint, float>();

    public int Count
    {
        get { return _allNodes.Count; }
    }
    public void Put(NavPoint node, float cost)
    {
        if (_allNodes.ContainsKey(node)) _allNodes[node] = cost;
        else _allNodes.Add(node, cost);
    }

    public NavPoint Get()
    {
        NavPoint node = null;
        float lowestValue = Mathf.Infinity;

        foreach (var item in _allNodes)
        {
            if (item.Value < lowestValue)
            {
                lowestValue = item.Value;
                node = item.Key;
            }
        }
        _allNodes.Remove(node);
        return node;
    }
}
