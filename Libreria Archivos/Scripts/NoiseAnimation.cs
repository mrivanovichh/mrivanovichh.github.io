
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NoiseAnimation : UdonSharpBehaviour
{
    public float speed = 1.0f;
    public float noiseScale = 1.0f;
    public float loopTime = 10.0f; // Time it takes for the noise to loop

    public bool moveOnX = true;
    public bool moveOnY = true;
    public bool moveOnZ = true;

    private Vector3 startPosition;
    private float startTime;

    private void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;

        float noiseX = moveOnX ? Mathf.PerlinNoise(elapsedTime * speed, 0) * 2 - 1 : 0;
        float noiseY = moveOnY ? Mathf.PerlinNoise(0, elapsedTime * speed) * 2 - 1 : 0;
        float noiseZ = moveOnZ ? Mathf.PerlinNoise(elapsedTime * speed, elapsedTime * speed) * 2 - 1 : 0;

        Vector3 offset = new Vector3(noiseX, noiseY, noiseZ) * noiseScale;
        transform.position = startPosition + offset;

        if (elapsedTime >= loopTime)
        {
            startTime = Time.time;
        }
    }



    /*public float speed = 1.0f;
    public float noiseScale = 1.0f;

    public bool moveOnX = true;
    public bool moveOnY = true;
    public bool moveOnZ = true;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float noiseX = moveOnX ? Mathf.PerlinNoise(Time.time * speed, 0) * 2 - 1 : 0;
        float noiseY = moveOnY ? Mathf.PerlinNoise(0, Time.time * speed) * 2 - 1 : 0;
        float noiseZ = moveOnZ ? Mathf.PerlinNoise(Time.time * speed, Time.time * speed) * 2 - 1 : 0;

        Vector3 offset = new Vector3(noiseX, noiseY, noiseZ) * noiseScale;
        transform.position = startPosition + offset;
    }*/
}
