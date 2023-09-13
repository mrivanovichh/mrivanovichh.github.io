
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PortalOn : UdonSharpBehaviour
{

    [Header("Prop Toggle")]
    public GameObject Prop;
    [Header("Key/Llave")]
    public Collider Key;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [Header("Play Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;


    [Header("Particles")]
    [SerializeField] public GameObject PartPref;
    [SerializeField] ParticleSystem particleSys;



  
    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {

        if (!player.isLocal) return;
        
        
            if (Prop) Prop.SetActive(true);

            if (animator) animator.Play(anim);

            if (audioSource) audioSource.PlayOneShot(audioClip);

            if (particleSys) particleSys.Play();


    }

   
        /*  if (other == Key)
          {
              Prop.SetActive(!Prop.activeSelf);

          }
          */

        //  GameObject VRCInstantiate(PartPref);
        // part.transform.position = Key.transform.position;

        //       SendCustomEventDelayedSeconds(nameof(PartPref), 2);
        //     Destroy(Key);
        //
        //
    
}
