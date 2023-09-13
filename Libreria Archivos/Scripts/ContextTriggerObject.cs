
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class ContextTriggerObject : UdonSharpBehaviour
{

   // [Header("Needed References")]
    //[SerializeField] Collider trigger;

    [Header("Key References")]
    [SerializeField] Collider key;

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

    [Header("Play Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;

    [Header("Options")]
    [SerializeField] bool localOnly;
    [SerializeField] bool oneTimeOnly;
    private void OnTriggerEnter(Collider other)
    {
        //if (localOnly && !trigger.isLocal) return;
        if (other == key)
        {
            foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }

        if (vrcSpawn) vrcSpawn.SetPositionAndRotation(targetSpawn.position, targetSpawn.rotation);

        //if (songManager) songManager.PlaySong(song);

        if (animator) animator.Play(anim);

        if (audioSource) audioSource.PlayOneShot(audioClip);

        if (particleSys) particleSys.Play();

        //if (oneTimeOnly) Destroy(trigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == key)
        {
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
        
            if (animator) animator.StopPlayback();
        }
    }
}
