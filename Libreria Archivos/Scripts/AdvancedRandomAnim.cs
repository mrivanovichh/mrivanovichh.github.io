
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AdvancedRandomAnim : UdonSharpBehaviour
{
    public float positionAmplitude = 1.0f;    // Amplitude for position adjustments
    public float speed = 2.0f;                // The speed of the animation

    public float rotationAmplitude = 30f;     // Amplitude for rotation adjustments
    public float rotationSpeed = 30f;         // Speed of constant rotation

    public float scaleAmplitude = 0.2f;       // Amplitude for scale adjustments
    public float scaleSpeed = 1f;             // Speed of scale adjustments
    
    public Vector3 movementAxis = new Vector3(0f, 1f, 0f);  // Axis along which to move
    public bool randomRotation = true;        // Toggle between random and constant rotation
    public Vector3 rotationAxes = new Vector3(0f, 1f, 0f);  // Axis along which to rotate
    public bool scaleEnabled = true;          // Toggle scale adjustments

    private Vector3 startPos;
    private Vector3 initialScale;
    private Quaternion startRotation;

    void Start()
    {
        startPos = transform.position; // Store the initial position
        initialScale = transform.localScale;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate the new Y position based on sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * positionAmplitude;

        // Update the object's position along the selected axis
        Vector3 newPosition = startPos + movementAxis * newY;
        transform.position = newPosition;

        // Adjust scale if scaleEnabled is true
        if (scaleEnabled)
        {
            float scaleMultiplier = 1f + Mathf.Sin(Time.time * scaleSpeed) * scaleAmplitude;
            Vector3 scaledSize = initialScale * scaleMultiplier;
            transform.localScale = scaledSize;
        }

        // Adjust rotation
        if (randomRotation)
        {
            Quaternion randomRotation = startRotation * Quaternion.Euler(
                Random.Range(-rotationAmplitude, rotationAmplitude) * rotationAxes.x,
                Random.Range(-rotationAmplitude, rotationAmplitude) * rotationAxes.y,
                Random.Range(-rotationAmplitude, rotationAmplitude) * rotationAxes.z
            );
            transform.rotation = randomRotation;
        }
        else
        {
            Quaternion constantRotation = startRotation * Quaternion.Euler(
                rotationAmplitude * rotationAxes.x * Mathf.Sin(Time.time * rotationSpeed),
                rotationAmplitude * rotationAxes.y * Mathf.Sin(Time.time * rotationSpeed),
                rotationAmplitude * rotationAxes.z * Mathf.Sin(Time.time * rotationSpeed)
            );
            transform.rotation = constantRotation;
        }
    }
}
