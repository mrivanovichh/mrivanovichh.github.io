
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using EnemyAI;

public class DetectPlayer : UdonSharpBehaviour
{
    public EnemyFollow AIController;
    [SerializeField] bool localOnly;

    [Header("Play Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        
    }
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        

        if (localOnly && !player.isLocal) return;

        if (audioSource) audioSource.PlayOneShot(audioClip);
        AIController.CurrentState = 1;

    }
}
