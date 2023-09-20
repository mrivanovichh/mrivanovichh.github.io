
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ChangeMat : UdonSharpBehaviour
{
    public Renderer Prop;
    public Material Mat1;
    public Material Mat2;
    public Collider Key;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other == Key)
        {
            Prop.material = Mat1;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other == Key)
        {
            Prop.material = Mat2;
          
        }


    }
}
