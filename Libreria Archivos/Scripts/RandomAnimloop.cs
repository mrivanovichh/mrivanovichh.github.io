
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RandomAnimloop : UdonSharpBehaviour
{
    public float amplitude = 1.0f;   // The distance the object moves up and down
    public float speed = 2.0f;       // The speed of the animation
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position
    }

    void Update()
    {
        // Calculate the new Y position based on sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
