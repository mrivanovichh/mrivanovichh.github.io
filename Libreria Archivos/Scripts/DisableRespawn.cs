
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DisableRespawn : UdonSharpBehaviour
{
    public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
    public Transform teleportPoint;
    public bool lerpOnRemote = false;
    VRCPlayerApi playerLoc;
    public Vector3 positionPoint;
    public Quaternion rotationPoint;
    int contador = 0;
    public int SlowRefreshByFPS = 180;

    void Start()
    {
        playerLoc = Networking.LocalPlayer;
    }
    private void Update()
    {
        TeleportPositionUpdate();
       /* if (contador == SlowRefreshByFPS)
        {
            TeleportPositionUpdate();
            contador = 0;
        }
        else
        {
            contador++;
          }
        */
    }


    public virtual void TeleportPositionUpdate()
    {
       
        positionPoint = playerLoc.GetPosition();
        rotationPoint = playerLoc.GetRotation();
        Debug.Log($"{playerLoc.displayName} .\nSu posición es {positionPoint}.\nSu rotacion es {rotationPoint}");
        Debug.Log(positionPoint);
        Debug.Log(rotationPoint);


    }


    public override void OnPlayerRespawn(VRCPlayerApi player)
    {

        // if (!player.isLocal) return;
        Networking.LocalPlayer.TeleportTo(positionPoint, rotationPoint, teleportOrientation, lerpOnRemote);
        //Networking.LocalPlayer.TeleportTo(playerLoc.GetPosition(), playerLoc.GetRotation(), teleportOrientation, lerpOnRemote);

        Debug.Log($"{playerLoc.displayName} hizo respawn.\nSu posición es {positionPoint}");


    }




}



/*public override void OnPlayerTriggerStay(VRCPlayerApi player) {
    if (!player.isLocal) return;
Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);

}

public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
{
 //   if (!player.isLocal) return;
    //    Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);

}*/


//player.GetPosition()= positionPoint;
//player.GetRotation()= rotationPoint;

//teleportPoint.position = positionPoint;

//teleportPoint.SetPositionAndRotation(player.GetPosition(), player.GetRotation());
//teleportPoint.Set
//teleportPoint.position = player.GetPosition();
//teleportPoint.rotation = player.GetRotation();
// teleportPoint.SetPositionAndRotation(resetpoint.position, resetpoint.rotation);
