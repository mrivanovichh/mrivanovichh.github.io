
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using InstanciasObjetos;
public class DestroySpawn : UdonSharpBehaviour
{
    public SummonObject var;
    void Start()
    {
        
    }

    public override void Interact()
    {
        Debug.Log("Dio click en Destroy");
        var.DestroyObj();
    }

}
