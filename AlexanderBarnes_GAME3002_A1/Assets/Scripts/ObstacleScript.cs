using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 pointA = new Vector3(-3.71f, 0.82f, -8.61f);
    Vector3 pointB = new Vector3(3.71f, 0.82f, -8.61f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}
