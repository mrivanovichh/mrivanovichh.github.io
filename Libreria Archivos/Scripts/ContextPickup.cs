
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ContextPickup : UdonSharpBehaviour
{
    [Header("Toggle Objects")]
    [SerializeField] GameObject[] toggleObjects;

    [Header("Change Spawn")]
    [SerializeField] Transform vrcSpawn;
    [SerializeField] Transform targetSpawn;

    [Header("Play Audio")]
    [SerializeField] AudioSource audioSource;
    [Header("Sounds pickup/Use/Up/Drop")]
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    [SerializeField] AudioClip audioClip3;
    [SerializeField] AudioClip audioClip4;
    [SerializeField] AudioClip audioClip5;

    [Header("Animator Config")]
    [SerializeField] Animator animator;
    [Header("Anims pickup/Use/Up/Drop")]
    [SerializeField] string anim1;
    [SerializeField] string anim2;
    [SerializeField] string anim3;
    [SerializeField] string anim4;
    [SerializeField] string anim5;

    [Header("Play Particle System pickup/Use/Up/Drop")]
    [SerializeField] ParticleSystem particleSys1;
    [SerializeField] ParticleSystem particleSys2;
    [SerializeField] ParticleSystem particleSys3;
    [SerializeField] ParticleSystem particleSys4;
    [SerializeField] ParticleSystem particleSys5;



    [Header("Options")]
    [SerializeField] bool localOnly;
    [SerializeField] bool oneTimeOnly;

    void Start()
    {
        
    }

    public override void OnPickup() {
        if (animator) animator.Play(anim1);
        if (audioSource) audioSource.PlayOneShot(audioClip1);
        if (particleSys1) particleSys1.Play();
    }

    public override void OnPickupUseDown() {
        //if (localOnly && !player.isLocal) return;
        
        /*if (toggleObjects.Length>=1)
        {
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
        */
         

       /* if (oneTimeOnly==true)
        {
            if (audioSource) audioSource.PlayOneShot(audioClip5);
            if (animator) animator.Play(anim5);
            if (particleSys5) particleSys5.Play();
            Destroy(this, 5);

        }
        */
        if (audioSource) audioSource.PlayOneShot(audioClip2);
        if (animator) animator.Play(anim2);
        if (particleSys2) particleSys2.Play();

        if (vrcSpawn) vrcSpawn.SetPositionAndRotation(targetSpawn.position, targetSpawn.rotation);
    }

    public override void OnPickupUseUp() {

        if (animator) animator.Play(anim3);
        if (audioSource) audioSource.PlayOneShot(audioClip3);
        if (particleSys3) particleSys3.Play();
    }
    public override void OnDrop() {
        if (animator) animator.Play(anim4);
        if (audioSource) audioSource.PlayOneShot(audioClip4);
        if (particleSys4) particleSys4.Play();
    }
}
