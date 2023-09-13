
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TeleportOnInteract : UdonSharpBehaviour
{
    public Transform teleportPoint;
    public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
    public bool lerpOnRemote = false;

    void Start()
    {
        
    }

    public override void Interact() {
        //if (!player.isLocal) return;

        Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);
    }
}
