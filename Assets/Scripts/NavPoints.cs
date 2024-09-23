using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    public int x;
    public int y;
    public bool blocked;
    public int cost = 0;
    public NavPointsMap parentNode;


    [SerializeField] GameObject wallPrefab;
    private HashSet<NavPoint> neighbours = new HashSet<NavPoint>();

    private void Awake()
    {
        if(blocked)
        {
            Instantiate(wallPrefab, transform.position, Quaternion.identity, transform.parent);
            parentNode.RemoveNavPoint(x, y);
        }
    }

    public NavPoint Initialize(int x, int y, bool blocked, NavPointsMap parent)
    {
        this.x = x;
        this.y = y;
        this.blocked = blocked;
        this.parentNode = parent;
        return this;
    }

    public HashSet<NavPoint> GetNeighbours()
    {
        Debug.Assert(parentNode != null);
        if (neighbours.Count != 0) return neighbours;

        NavPoint neighbour = parentNode.GetPoint(x, y - 1);

        if (neighbour != null)
        {
            neighbours.Add(neighbour);
        }

        neighbour = parentNode.GetPoint(x, y + 1);

        if (neighbour != null)
        {
            neighbours.Add(neighbour);
        }

        neighbour = parentNode.GetPoint(x - 1, y);

        if (neighbour != null)
        {
            neighbours.Add(neighbour);
        }

        neighbour = parentNode.GetPoint(x + 1, y);

        if (neighbour != null)
        {
            neighbours.Add(neighbour);
        }


        return neighbours;

    }
}
