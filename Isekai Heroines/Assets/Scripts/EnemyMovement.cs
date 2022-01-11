using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting patrol..");
        foreach (Waypoint waypoint in path)
        {
            Debug.Log("Visiting: "+waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending patrol");
    }
}
