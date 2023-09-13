
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OrbitAnimation : UdonSharpBehaviour
{
    public float orbitSpeed = 30f; // Speed of the orbit in degrees per second
    public float orbitRadius = 5f; // Radius of the orbit circle
    public bool orbitAroundX = true;
    public bool orbitAroundY = true;
    public bool orbitAroundZ = true;

    private Vector3 initialPosition;
    private float angle = 0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new angle based on time and orbit speed
        angle += orbitSpeed * Time.deltaTime;

        // Calculate new positions for each axis
        float x = orbitAroundX ? initialPosition.x + orbitRadius * Mathf.Cos(Mathf.Deg2Rad * angle) : transform.position.x;
        float y = orbitAroundY ? initialPosition.y + orbitRadius * Mathf.Sin(Mathf.Deg2Rad * angle) : transform.position.y;
        float z = orbitAroundZ ? initialPosition.z + orbitRadius * Mathf.Sin(Mathf.Deg2Rad * angle) : transform.position.z;

        Vector3 newPosition = new Vector3(x, y, z);

        // Move the object to the new position
        transform.position = newPosition;
    }
}
