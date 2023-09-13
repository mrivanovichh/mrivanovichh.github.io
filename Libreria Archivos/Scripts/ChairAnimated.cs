
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using Player.Detector;

public class ChairAnimated : UdonSharpBehaviour
{
    public VRCStation station;
    [HideInInspector]
    public VRCPlayerApi seated;
    //Manda a llamar la clase Player detector 
    //Se asigna en el editor y ya se puede interactuar con sus variables
    public PlayerDetector LocalPlayer;

    [Header("Play Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;
    [SerializeField] string anim2;

    public void Sit()
    {
        if (!Utilities.IsValid(seated))
        {
            station.UseStation(Networking.LocalPlayer);
        }
        else if (seated == Networking.LocalPlayer)
        {
            station.ExitStation(Networking.LocalPlayer);
        }
    }
    public override void Interact()
    {
        Networking.LocalPlayer.UseAttachedStation();
       
    }

    public virtual void OnStationEntered(VRC.SDKBase.VRCPlayerApi player)
    {
        //Resta de la variable de PlayerDetector
        LocalPlayer.players--;
        
        if (animator) animator.Play(anim);
    }
    public virtual void OnStationExited(VRC.SDKBase.VRCPlayerApi player)
    {
        if (animator) animator.Play(anim2);
   
    }
}
