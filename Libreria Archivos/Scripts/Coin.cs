
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using WorldControls;

public class Coin : UdonSharpBehaviour
{

    [Header("World Manager")]
    public WorldManager _worldManager;

    [Header("References")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip completeClip;


    [SerializeField] Animator animator;
    [SerializeField] string anim;

    void Start()
    {

    }

    public override void Interact()
    {
        if(animator) animator.Play(anim);
        if (_audioSource) _audioSource.PlayOneShot(completeClip);
        Complete = true;
    }



    //[UdonSynced, FieldChangeCallback(nameof(Complete))]
    private bool _complete;
    public bool Complete
    {
        set
        {
            _complete = value;
            _worldManager._CoinUpdate();
            Debug.Log("Se completo una moneda");

        }
        get => _complete;

        //
    }
    

}
