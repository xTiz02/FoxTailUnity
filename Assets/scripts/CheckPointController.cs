using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instancia;
    public CheckPoint[] checkPoints;
    public Vector3 spawnPoint;
    private void Awake()
    {
        instancia = this;
    }
    private void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();
        spawnPoint = PlayerScript.instancia.transform.position;
    }

    
    void Update()
    {
        
    }

    public void DesactivarCheckPoints()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
