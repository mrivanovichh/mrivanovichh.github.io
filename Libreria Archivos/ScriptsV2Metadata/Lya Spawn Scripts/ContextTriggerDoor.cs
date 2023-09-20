
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class ContextTriggerDoor : UdonSharpBehaviour
{
    [Header("Needed References")]
    [SerializeField] Collider trigger;

    [Header("Toggle Objects")]
    [SerializeField] GameObject[] toggleObjects;

    [Header("Change Spawn")]
    [SerializeField] Transform vrcSpawn;
    [SerializeField] Transform targetSpawn;

    [Header("Play Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [Header("Play Particle System")]
    [SerializeField] ParticleSystem particleSys;

    [Header("Play Song (Index)")]
    //[SerializeField] SongManager songManager;
    [SerializeField] int song;

    [Header("Play Animation Enter")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;

    [Header("Play Animation Exit")]
    //  [SerializeField] Animator animator2;
    [SerializeField] string anim2;


    [Header("Options")]
    [SerializeField] bool localOnly;
    [SerializeField] bool oneTimeOnly;
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (localOnly && !player.isLocal) return;

        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }

        if (vrcSpawn) vrcSpawn.SetPositionAndRotation(targetSpawn.position, targetSpawn.rotation);

       // if (songManager) songManager.PlaySong(song);

        if (animator) animator.Play(anim);

        if (audioSource) audioSource.PlayOneShot(audioClip);

        if (particleSys) particleSys.Play();

        if (oneTimeOnly) Destroy(trigger);
    }

    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (localOnly && !player.isLocal) return;

        if (animator) animator.Play(anim2);


    }



}
