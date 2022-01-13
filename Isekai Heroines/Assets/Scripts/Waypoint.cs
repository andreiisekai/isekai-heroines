using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as it is a data class
    [SerializeField] Color exploredColor;
    public bool isExplored;
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector3 gridPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector3 GetGridPos()
    {
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPos.y = Mathf.RoundToInt(transform.position.y / gridSize);
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize);
        return gridPos;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
