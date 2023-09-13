
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnTrigger : UdonSharpBehaviour
{
    [Header("Door/Puerta")]
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
    [SerializeField] ParticleSystem part;
    


    void Update()
    {
    }
        private void OnTriggerEnter(Collider other)
    {
  
            if (other == Key)
            {
            Prop.SetActive(!Prop.activeSelf);


            if (animator) animator.Play(anim);

            if (audioSource) audioSource.PlayOneShot(audioClip);

        }

    }

    private void OnTriggerExit(Collider other)
        {
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
    }
