
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RotationOnly : UdonSharpBehaviour
{
    [SerializeField] private float rotationTime = 1.0f; // Time in seconds for a 360-degree rotation
    [SerializeField] private Vector3 targetRotationAxis = new Vector3(0f, 0f, 1f); // Axis to rotate around

    private void Update()
    {
        float rotationAngle = 360f * (Time.deltaTime / rotationTime);

        // Rotate the GameObject around the target rotation axis
        transform.Rotate(targetRotationAxis, rotationAngle);
    }
}
