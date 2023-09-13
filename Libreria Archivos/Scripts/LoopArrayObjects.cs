
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LoopArrayObjects : UdonSharpBehaviour
{
    public Transform[] targetObjects;
    public float[] minAmplitudes;
    public float[] maxAmplitudes;
    public float[] minSpeeds;
    public float[] maxSpeeds;

    private Vector3[] startPositions;

    void Start()
    {
        int numObjects = Mathf.Min(targetObjects.Length, minAmplitudes.Length, maxAmplitudes.Length, minSpeeds.Length, maxSpeeds.Length);
        startPositions = new Vector3[numObjects];

        for (int i = 0; i < numObjects; i++)
        {
            startPositions[i] = targetObjects[i].position;
        }
    }

    void Update()
    {
        int numObjects = Mathf.Min(targetObjects.Length, minAmplitudes.Length, maxAmplitudes.Length, minSpeeds.Length, maxSpeeds.Length);

        for (int i = 0; i < numObjects; i++)
        {
            float randomSpeed = Random.Range(minSpeeds[i], maxSpeeds[i]);
            float randomAmplitude = Random.Range(minAmplitudes[i], maxAmplitudes[i]);

            float newY = startPositions[i].y + Mathf.Sin(Time.time * randomSpeed) * randomAmplitude;

            targetObjects[i].position = new Vector3(targetObjects[i].position.x, newY, targetObjects[i].position.z);
        }
    }
}
