using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale += 5.0f;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale -= 5.0f;
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            Time.timeScale = 1.0f;
        }
    }
}
