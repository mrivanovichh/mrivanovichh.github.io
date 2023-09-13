
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CubeCounter : UdonSharpBehaviour
{
    [Header("Prop Toggle Final")]
    public GameObject Prop;
    [Header("Cubes")]
    public Collider Cube1;
    public Collider Cube2;
    public Collider Cube3;
    public Collider Cube4;
    public Collider Cube5;
    public Collider Cube6;
    public Collider Cube7;
    public Collider Cube8;
    public Collider Cube9;
    public Collider Cube10;

    [Header("Cubos Toggle")]
    public GameObject CubeG1;
    public GameObject CubeG2;
    public GameObject CubeG3;
    public GameObject CubeG4;
    public GameObject CubeG5;
    public GameObject CubeG6;
    public GameObject CubeG7;
    public GameObject CubeG8;
    public GameObject CubeG9;
    public GameObject CubeG10;

    public int keyCount;
    [Header("Prop Toggle feedback")]
    //[SerializeField] GameObject[] toggleObjects;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [Header("Play Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string anim;
    [Header("Particles")]
    [SerializeField] public GameObject PartPref;
    [SerializeField] ParticleSystem particleSys;


    void Start()
    {
        keyCount = 0;
        Debug.Log("llaves inicializadas"+keyCount);
    }


    /*public void objToggle()
    {
        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    
         
          public void CubesUpdate() {

    }

         */


    private void OnTriggerEnter(Collider other)
    {

        if (other == Cube1)
        {   keyCount++;
            CubeG1.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();}

        if (other == Cube2)
        {
            keyCount++;
            CubeG2.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube3)
        {
            keyCount++;
            CubeG3.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube4)
        {
            keyCount++;
            CubeG4.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube5)
        {
            keyCount++;
            CubeG5.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube6)
        {
            keyCount++;
            CubeG6.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube7)
        {
            keyCount++;
            CubeG7.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube8)
        {
            keyCount++;
            CubeG8.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube9)
        {
            keyCount++;
            CubeG9.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }

        if (other == Cube10)
        {
            keyCount++;
            CubeG10.SetActive(false);
            if (animator) animator.Play(anim);
            if (audioSource) audioSource.PlayOneShot(audioClip);
            if (particleSys) particleSys.Play();
        }


        if (keyCount == 5) {
            Prop.SetActive(!Prop.activeSelf);
            Debug.Log("llaves completadas");
        }
        Debug.Log("Llevas "+keyCount+"Llaves");

        /* foreach (Collider key in Keys)
 {
     //key.SetActive(!key.activeSelf);



 switch (other) {
    case Cube1:
        break;

}


 }*/
        // if (other.gameObject.name == "key");
        //private Collider Cubee;

    }
}
