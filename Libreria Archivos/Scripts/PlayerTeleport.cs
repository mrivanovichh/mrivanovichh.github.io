
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTeleport : UdonSharpBehaviour
{

    public Transform teleportPoint;
    public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
    public bool lerpOnRemote = false;
    [SerializeField] GameObject[] toggleObjects;

    void Start()
    {

    }
    public void objToggle()
    {
        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (!player.isLocal) return;
        objToggle();




            Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);
        
    }
}