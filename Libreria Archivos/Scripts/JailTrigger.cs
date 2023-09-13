
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class JailTrigger : UdonSharpBehaviour
{
    [SerializeField] private JailBatManager manager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(!Utilities.IsValid(player)) return;
        if(player.isLocal) return;
        
        SendCustomNetworkEvent(NetworkEventTarget.All, nameof(PlayBonk));
        
        Networking.SetOwner(Networking.LocalPlayer,manager.gameObject);
        manager.PlayerToJail = player.playerId;
        manager.RequestSerialization();
    }

    public void PlayBonk()
    {
        audioSource.PlayOneShot(clip);
    }
}
