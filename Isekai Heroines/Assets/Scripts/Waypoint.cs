using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isStart;
    [SerializeField] bool isEnd;
    [SerializeField] Color customColor;
    const int gridSize = 10;
    Vector3 gridPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public bool getIsStart()
    {
        return isStart;
    }

    public bool getIsEnd()
    {
        return isEnd;
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
        if(isStart || isEnd)
        {
            topMeshRenderer.material.color = customColor;
        }
        else
        {
            topMeshRenderer.material.color = color;
        }
    }
}
