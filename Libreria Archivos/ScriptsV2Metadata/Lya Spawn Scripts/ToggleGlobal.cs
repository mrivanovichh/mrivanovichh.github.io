
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OBJECT : UdonSharpBehaviour
{
    public GameObject toggleObject;

    [UdonSynced]
    public bool isEnabled;

    private void Start()
    {
        isEnabled = toggleObject.activeSelf;
    }

    public override void OnDeserialization()
    {
        if (!Networking.IsOwner(gameObject))
            toggleObject.SetActive(isEnabled);
    }
    //Esto es para usarlo en un Boton lanzar "TriggerObj"
    public void TriggerObj()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(InteractObj));
    }
    //Accion de toggle
    public void InteractObj()
    {
        
        isEnabled = !isEnabled;
        toggleObject.SetActive(isEnabled);

        //RequestSerialization();
    }
    //Para usarse con un Pick Up
    public override void Interact()
    {
        if (!Networking.IsOwner(gameObject))
            Networking.SetOwner(Networking.LocalPlayer, gameObject);

        isEnabled = !isEnabled;
        toggleObject.SetActive(isEnabled);

        RequestSerialization();
    }
}

