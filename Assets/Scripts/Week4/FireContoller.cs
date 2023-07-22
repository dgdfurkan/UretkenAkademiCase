using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireContoller : MonoBehaviour
{
    public LayerMask obstacleLayer;

    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    void FireWeapon()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
