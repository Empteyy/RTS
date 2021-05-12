using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigate : MonoBehaviour
{
    public float moveSpeed;
    public GameObject pointA;
    public GameObject pointB;
    public bool reverseMove = false;
    public Transform user;
    float startTime;
    float journeyLength;
    float distCovered;
    float fracJourney;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(pointA.transform.position, pointB.transform.position);
    }
    void Update()
    {
        distCovered = (Time.time - startTime) * moveSpeed;
        fracJourney = distCovered / journeyLength;
        if (reverseMove)
        {
            user.position = Vector3.Lerp(pointB.transform.position, pointA.transform.position, fracJourney);
        }
        else
        {
            user.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, fracJourney);
        }
        if ((Vector3.Distance(user.position, pointB.transform.position) == 0.0f || Vector3.Distance(user.position, pointA.transform.position) == 0.0f)) //Checks if the object has travelled to one of the points
        {
            if (reverseMove)
            {
                reverseMove = false;
            }
            else
            {
                reverseMove = true;
            }
            startTime = Time.time;
        }
    }
}