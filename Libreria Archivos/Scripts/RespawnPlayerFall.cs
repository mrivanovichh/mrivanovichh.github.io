
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RespawnPlayerFall : UdonSharpBehaviour
{
    [Header("Teleport Point")]
    public Transform teleportPoint;
    public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
    public bool lerpOnRemote = false;
    [Header("Options")]
    [SerializeField] bool localOnly;

    void Start()
    {
        
    }
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (localOnly && !player.isLocal) return;

        Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);

    }

    }
