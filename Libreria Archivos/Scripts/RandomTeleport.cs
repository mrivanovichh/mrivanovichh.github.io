
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RandomTeleport : UdonSharpBehaviour
{

    public Transform teleportPoint;
    public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
    public bool lerpOnRemote = false;
    [SerializeField] GameObject[] toggleObjects;
    //Rango de 0 a 100 %
    public int Range = 5;
    void Start()
    {

    }

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (!player.isLocal) return;

        if (Random.Range(0, 100) < Range)
        {

            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(true);
            }

            Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);
        }
    }
}
