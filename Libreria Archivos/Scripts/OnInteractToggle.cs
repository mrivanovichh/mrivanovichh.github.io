
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractToggle : UdonSharpBehaviour
{
    [Header("Toggles")]
    public GameObject[] Prop;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [Header("Play Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;


    [Header("Particles")]
    [SerializeField] public GameObject particleObj;
    [SerializeField] ParticleSystem particleSys;


    void Start()
    {
        
    }
    public void objToggle()
    {
        foreach (GameObject obj in Prop)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    public override void Interact()
    {
        objToggle();
        if (animator) animator.Play(anim);

        if (audioSource) audioSource.PlayOneShot(audioClip);

        if (particleSys) particleSys.Play();

    }


}
