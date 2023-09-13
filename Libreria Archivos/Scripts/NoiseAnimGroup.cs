
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NoiseAnimGroup : UdonSharpBehaviour
{
    public float speed = 1.0f;
    public float noiseScale = 1.0f;
    public float loopTime = 10.0f; // Time it takes for the noise to loop

    public bool moveOnX = true;
    public bool moveOnY = true;
    public bool moveOnZ = true;

    public GameObject[] objectsToMove; // Array of game objects affected by noise

    private Vector3[] startPositions;
    private float[] startTimes;

    private void Start()
    {
        // Store the initial positions of the objects and their starting times
        startPositions = new Vector3[objectsToMove.Length];
        startTimes = new float[objectsToMove.Length];

        for (int i = 0; i < objectsToMove.Length; i++)
        {
            startPositions[i] = objectsToMove[i].transform.position;
            startTimes[i] = Random.Range(0f, loopTime); // Generate random starting time offsets
        }
    }

    private void Update()
    {
        float currentTime = Time.time;

        for (int i = 0; i < objectsToMove.Length; i++)
        {
            float elapsedTime = currentTime - startTimes[i];

            float noiseX = moveOnX ? Mathf.PerlinNoise(elapsedTime * speed, 0) * 2 - 1 : 0;
            float noiseY = moveOnY ? Mathf.PerlinNoise(0, elapsedTime * speed) * 2 - 1 : 0;
            float noiseZ = moveOnZ ? Mathf.PerlinNoise(elapsedTime * speed, elapsedTime * speed) * 2 - 1 : 0;

            Vector3 offset = new Vector3(noiseX, noiseY, noiseZ) * noiseScale;
            objectsToMove[i].transform.position = startPositions[i] + offset;

            if (elapsedTime >= loopTime)
            {
                startTimes[i] = currentTime;
            }
        }
    }
}
