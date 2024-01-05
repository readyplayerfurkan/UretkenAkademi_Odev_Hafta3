using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotateVec;
    [SerializeField] private float rotateAngle;
    private void Update()
    {
        gameObject.transform.Rotate(rotateVec, rotateAngle);
    }
}
