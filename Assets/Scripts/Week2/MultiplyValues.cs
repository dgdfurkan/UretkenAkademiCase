using System;
using UnityEngine;

namespace GunduzDev
{
	public class MultiplyValues : MonoBehaviour
	{
        void Start()
        {
            GenerateMultiples(10,84,6);
        }

        void GenerateMultiples(int minNumber, int maxNumber, int multiplier)
        {
            if (multiplier <= 0)   // Multiplier must be positive
            {
                Debug.Log($"Multiplier ({multiplier}) must be positive");
                return;
            }
            else if (multiplier > maxNumber)   // Multiplier must be lesser than MaxNumber
            {
                Debug.Log($"Multiplier ({multiplier}) must be lesser than MaxNumber ({maxNumber})");
                return;
            }

            if (maxNumber < minNumber)   // MaxNumber must be higher than MinNumber
            {
                Debug.Log($"MaxNumber ({maxNumber}) must be higher than MinNumber ({minNumber})");
                return;
            }

            for (int i = 1; i <= multiplier; i += 1)   // Starts from 1 to Multiplier
            {
                string multiples = $"Multiples of {i}: ";
                for (int j = minNumber; j <= maxNumber; j++)   // Starts from MinNumber to MaxNumber
                {
                    if (j % i == 0)
                    {
                        multiples += j + ", ";
                    }
                }
                Debug.Log(multiples.TrimEnd(',', ' '));   // After for print all values, Trim.End delete the last ","
            }
        }
    }
}
