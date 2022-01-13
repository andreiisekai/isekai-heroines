using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector3,Waypoint> grid = new Dictionary<Vector3,Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    Vector3[] directions =
    {
        Vector3.up, Vector3.down, Vector3.forward, Vector3.right, Vector3.back,Vector3.left,
    };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

    void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
        Debug.Log("Finished pathfinding");
    }

    void HaltIfEndFound()
    {
        if (searchCenter.Equals(endWaypoint))
        {
            isRunning = false;
        }
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
                grid.Add(gridPos, waypoint);
            }
        }
    }

    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        Vector3 startCoords = searchCenter.GetGridPos();
        foreach (Vector3 direction in directions)
        {
            Vector3 neighbourCoords = startCoords + direction;
            if(grid.ContainsKey(neighbourCoords))
            {
                QueueNewNeighbour(neighbourCoords);
            }
        }
    }

    void QueueNewNeighbour(Vector3 neighbourCoords)
    {
        Waypoint neighbour = grid[neighbourCoords];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else 
        { 
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }
}
