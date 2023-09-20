
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class UiBotonGlobal : UdonSharpBehaviour
{
    public AudioSource soundFX;
    //public GameObject toggleObject;
    public AudioClip clip1;

    private void Start()
    {
        
    }

    public void TriggerSound()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(PlaySound));
    }

    public void PlaySound()
    {
        soundFX.PlayOneShot(clip1);
  
    }
}
