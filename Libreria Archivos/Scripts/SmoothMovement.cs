
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SmoothMovement : UdonSharpBehaviour
{
    public Transform targetTransform; // The target transformation to follow
    public float smoothSpeed = 5.0f;   // The speed of smooth movement

    private void Update()
    {
        if (targetTransform != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = targetTransform.position;

            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
