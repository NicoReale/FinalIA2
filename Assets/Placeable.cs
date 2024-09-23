using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public abstract class Placeable : MonoBehaviour
{
    [SerializeField] int nodeX, nodeY;
    [SerializeField] private NavPoint _node;
    private HashSet<NavPoint> _neighbours;

    public NavPoint Node { get { return _node; } }

    public NavPoint getPoint()
    {
        return _node;
    }
    public virtual void Initialize()
    {
        _node = NavPointsMap.instance.GetPoint(nodeX, nodeY);
        if(_node.blocked)
        {
            _node = _node.GetNeighbours().First(node => !node.blocked);
        }
        _neighbours = _node.GetNeighbours();
        transform.position = _node.transform.position;
    }
}
