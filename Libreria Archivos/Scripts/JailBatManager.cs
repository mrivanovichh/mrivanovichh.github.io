
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class JailBatManager : UdonSharpBehaviour
{
    [SerializeField] private Transform teleportTransform;

    [UdonSynced, FieldChangeCallback(nameof(PlayerToJail))] 
    private int _playerToJail;

    public int PlayerToJail
    {
        set
        {
            _playerToJail = value;

            if (VRCPlayerApi.GetPlayerById(_playerToJail).isLocal)
            {
                Networking.LocalPlayer.TeleportTo(teleportTransform.position,teleportTransform.rotation);
            }
        }
        get => _playerToJail;
    }

    
}
