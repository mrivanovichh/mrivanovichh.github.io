
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RotationGroup : UdonSharpBehaviour
{
    [SerializeField] private GameObject[] gameObjectsToRotate;

    [SerializeField]
    private float minSpeed = 10f;
    [SerializeField]
    private float maxSpeed = 50f;

    private Vector3[] rotationAxes;
    private float[] rotationSpeeds;

    private void Start()
    {
        rotationAxes = new Vector3[gameObjectsToRotate.Length];
        rotationSpeeds = new float[gameObjectsToRotate.Length];

        for (int i = 0; i < gameObjectsToRotate.Length; i++)
        {
            if (gameObjectsToRotate[i] != null)
            {
                rotationAxes[i] = Random.insideUnitSphere.normalized;
                rotationSpeeds[i] = Random.Range(minSpeed, maxSpeed);

                gameObjectsToRotate[i].transform.rotation = Random.rotation; // Optional: Set a random initial rotation.
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < gameObjectsToRotate.Length; i++)
        {
            if (gameObjectsToRotate[i] != null)
            {
                gameObjectsToRotate[i].transform.Rotate(rotationAxes[i] * rotationSpeeds[i] * Time.deltaTime);
            }
        }
    }
}


/*    

[SerializeField] private GameObject[] gameObjectsToRotate;

    [SerializeField]
    private float minSpeed = 10f;
    [SerializeField]
    private float maxSpeed = 50f;

    private Vector3[] rotationAxes;
    private float[] rotationSpeeds;

    private void Start()
    {
        rotationAxes = new Vector3[gameObjectsToRotate.Length];
        rotationSpeeds = new float[gameObjectsToRotate.Length];

        for (int i = 0; i < gameObjectsToRotate.Length; i++)
        {
            if (gameObjectsToRotate[i] != null)
            {
                rotationAxes[i] = Random.insideUnitSphere.normalized;
                rotationSpeeds[i] = Random.Range(minSpeed, maxSpeed);

                gameObjectsToRotate[i].transform.rotation = Random.rotation; // Optional: Set a random initial rotation.
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < gameObjectsToRotate.Length; i++)
        {
            if (gameObjectsToRotate[i] != null)
            {
                gameObjectsToRotate[i].transform.Rotate(rotationAxes[i] * rotationSpeeds[i] * Time.deltaTime);
            }
        }
    }


*/
