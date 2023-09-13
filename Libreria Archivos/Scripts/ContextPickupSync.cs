
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
//using VRC.Udon;
using VRC.Udon.Common.Interfaces;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class ContextPickupSync : UdonSharpBehaviour
{

    [Header("Play Audio")]
    [SerializeField] AudioSource audioSource;
    [Header("Sounds pickup/Use/Up/Drop")]
    [SerializeField] AudioClip audioClip1;

    [Header("Animator Config")]
    [SerializeField] Animator animator;
    [Header("Anims pickup/Use/Up/Drop")]
    [SerializeField] string anim1;

    [Header("Play Particle System pickup/Use/Up/Drop")]
    [SerializeField] private ParticleSystem particleSys;


    public override void OnPickupUseDown()
    {
        SendCustomNetworkEvent(NetworkEventTarget.All, nameof(Trigger));
    }

    public void Trigger()
    {
        if (audioSource) audioSource.PlayOneShot(audioClip1);
        if (animator) animator.Play(anim1);
        if (particleSys) particleSys.Play();


    }

}
