using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    TextMeshPro textMeshPro;
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = waypoint.GetGridPos() * gridSize;
    }

    void UpdateLabel()
    {
        Vector3 gridPos = waypoint.GetGridPos();
        string labelText = gridPos.x + "," + gridPos.y + "," + gridPos.z;
        textMeshPro.text = labelText;
        gameObject.name = labelText;
    }
}
