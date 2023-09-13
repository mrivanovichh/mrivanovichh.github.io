using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class InteractSynced : UdonSharpBehaviour
{
    [SerializeField] private GameObject[] toggleObjects;

    [UdonSynced, FieldChangeCallback(nameof(Enabled))]
    private bool _enabled;

    public bool Enabled
    {
        set
        {
            _enabled = value;
            SetActive(_enabled);
        }
        get => _enabled;
    }

    private void SetActive(bool value)
    {
        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(value);
        }
    }

    public void _Toggle()
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }

        Enabled = !Enabled;
        RequestSerialization();
    }
    public override void Interact()
    {
        _Toggle();

    }

}
