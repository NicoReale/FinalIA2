using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavPointsMap : MonoBehaviour
{
    [SerializeField] List<NavPoint> navPoints = new List<NavPoint>();

    public static NavPointsMap instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
        {
            instance = this;
        }
    }

    public NavPoint GetRandomPoint()
    {
        if (navPoints.Count == 0)
        {
            Debug.LogError("NavPoints list is empty.");
            return null;
        }

        int randomIndex = Random.Range(0, navPoints.Count);
        return navPoints[randomIndex];
    }

    public NavPoint GetPoint(int x, int y)
    {
        return navPoints.Where(p => p.x == x && p.y == y).FirstOrDefault();
    }

    public void AddNavPoint(NavPoint point)
    {
        navPoints.Add(point);
    }

    public void RemoveNavPoint(int x, int y)
    {
        navPoints.RemoveAll(point => point.x == x && point.y == y);
    }

    public void ClarAllPoints()
    {
        navPoints.Clear();
    }

    public NavPoint GetClosestNavPoint(Vector3 position)
    {
        var hits = Physics.OverlapSphere(position, 1.9f);
        var closest = Mathf.Infinity;
        NavPoint point = null;

        if(hits.Length > 0)
        {
            foreach(var hit in hits)
            {
                if(hit.GetComponent<NavPoint>() != null && Vector2.Distance(position, hit.transform.position) < closest)
                {
                    closest = Vector2.Distance(position, hit.transform.position);
                    point = hit.GetComponent<NavPoint>();
                }
            }
        }
        return point;
    }
}
