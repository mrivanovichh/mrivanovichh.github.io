
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JailBat : UdonSharpBehaviour
{
    [SerializeField] private Collider collider;
    
    public override void OnPickup()
    {
        collider.enabled = true;
    }

    public override void OnDrop()
    {
        collider.enabled = false;
    }
}
