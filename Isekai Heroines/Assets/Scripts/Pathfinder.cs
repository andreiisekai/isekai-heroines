using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector3,Waypoint> grid = new Dictionary<Vector3,Waypoint>();
    Vector3[] directions =
    {
        Vector3.up, Vector3.down, Vector3.forward, Vector3.back,Vector3.left, Vector3.right,
    };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ExploreNeighbours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                waypoint.SetTopColor(Color.red);
                grid.Add(gridPos, waypoint);
            }
        }
        Debug.Log("Loaded " + grid.Count + " blocks");
    }

    void ExploreNeighbours()
    {
        Vector3 startWaypoint = GetStartWaipoint().GetGridPos();
        foreach (Vector3 direction in directions)
        {
            Vector3 exploredWaypoint = startWaypoint + direction;
            if(grid.ContainsKey(exploredWaypoint))
            {
                grid[exploredWaypoint].SetTopColor(Color.blue);
            }
        }
    }

    Waypoint GetStartWaipoint()
    {
        foreach (var point in grid)
        {
            if(point.Value.getIsStart())
            {
                return point.Value;
            }
        }
        return null;
    }
}
