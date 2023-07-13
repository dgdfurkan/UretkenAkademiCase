using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] public float distanceFromSun;
    [SerializeField] public float rotationPeriod;
    [SerializeField] public float orbitPeriod;

    private void Awake()
    {
        distanceFromSun = transform.position.x;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationPeriod * Time.deltaTime);
        
        transform.RotateAround(Vector3.zero, Vector3.up, orbitPeriod * Time.deltaTime);
    }
}