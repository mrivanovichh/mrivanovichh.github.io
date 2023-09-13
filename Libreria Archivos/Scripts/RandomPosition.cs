
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RandomPosition : UdonSharpBehaviour
{
    // Adjust the movement speed as needed
    public float moveSpeed = 1f;
    public float maxDistance = 10f;
    // public RangeAttribute rangeMov(-1f,1f);
    public float MinValue = -1f;
    public float MaxValue = 1f;

    private Vector3 centerPoint = Vector3.zero;

    private void Start()
    {
        centerPoint = transform.position; // Store the initial position as the center point
    }


    private void Update()
    {
        // Generate random movement direction
        Vector3 randomDirection = new Vector3(Random.Range(MinValue, MaxValue), 0f, Random.Range(MinValue, MaxValue));
        // Normalize the direction to maintain consistent speed
        randomDirection.Normalize();


        // Calculate new position
        //Vector3 newPosition = transform.position + randomDirection * moveSpeed * Time.deltaTime;
        // Move the object
        //transform.position = newPosition;


        // Calculate new position
        Vector3 newPosition = centerPoint + randomDirection * maxDistance;
        // Move the object
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }


}