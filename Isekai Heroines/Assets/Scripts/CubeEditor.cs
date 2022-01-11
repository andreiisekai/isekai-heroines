using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] float gridSize = 10f;

    TextMeshPro textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapPosition();
    }

    void SnapPosition()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMeshPro.text = labelText;
        gameObject.name = labelText;
    }
}
