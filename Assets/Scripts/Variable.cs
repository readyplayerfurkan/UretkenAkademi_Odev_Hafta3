using System;
using UnityEngine;

public class Variable : MonoBehaviour
{
    public float intensityValue;

    private void Start()
    {
        intensityValue = 5.0f;
    }

    public void ShowTheIntensityValue()
    {
        Debug.Log("Value : " + intensityValue);
    }
}
