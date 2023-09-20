using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Reflection : UdonSharpBehaviour
{
    public ReflectionProbe refleccion;
    public int frames = 30;
    private int contador;

    void Update()
    {
        if (frames >= contador)
        {
            contador++;
        }
        else
        {
            contador = 0;
            refleccion.RenderProbe();
            Debug.Log("update");
        }
    }
}