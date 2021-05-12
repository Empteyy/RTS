using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorker : MonoBehaviour
{
    public GameObject goldWorker;

    void Start()
    {
        Instantiate(goldWorker, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
