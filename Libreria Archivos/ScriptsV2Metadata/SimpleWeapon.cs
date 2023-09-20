
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


public class SimpleWeapon : UdonSharpBehaviour
{
    [Header("PickGun")]
    public VRC_Pickup pickup;
    [Header("Toggle Shoot")]
    public GameObject Prop;
    [Header("Particulas")]
    public ParticleSystem Particles;

    private bool triggerdown = false;
    private VRCPlayerApi localUser;



    void Start()
    {
        localUser = Networking.LocalPlayer;
        pickup = (VRC_Pickup)GetComponent(typeof(VRC_Pickup));
    }
    private void Update()
    {
    }

    public override void OnPickupUseDown()
    {
        //En esta parte pones acciones para cuando el Pickup Es presionado

        Particles.Play();
        //particleSystem.Play(ps);
        //Prop.SetActive(true);

    }
    public override void OnPickupUseUp()
    {
        //Prop.SetActive(false);
    }
    public virtual void OnDrop()
    {
    }
    public virtual void OnPickup()
    {
    }

}


/*public class SimpleWeapon : UdonSharpBehaviour
{
    [Header("PickGun")]
    public VRC_Pickup pickup;
    [Header("Toggle Shoot")]
    public GameObject Prop;

    private bool triggerdown = false;
    private VRCPlayerApi localUser;

    void Start()
    {
        localUser = Networking.LocalPlayer;
        pickup = (VRC_Pickup)GetComponent(typeof(VRC_Pickup));
    }


    private void Update(){
        // if (pickup.IsHeld){
        //Prop.SetActive(!Prop.activeSelf);
        //}


        
        /*if (pickup.IsHeld)
        {
            if (triggerdown)
            {
                Prop.SetActive(true);
                Debug.Log("1");
            }
            else
            {
                Prop.SetActive(false);
                Debug.Log("2");
            }
        }
        ***

    }



    public override void OnPickupUseDown()
    {
          Prop.SetActive(true);
          triggerdown = true;
        Debug.Log("3");
    }
    public override void OnPickupUseUp()
    {

        triggerdown = false;
        Debug.Log("4");
    }
    public virtual void OnDrop()
    {
        triggerdown = false;
        //localUser.SetGravityStrength(gravitysave);
    }
    public virtual void OnPickup()
    {
        //gravitysave = localUser.GetGravityStrength();
    }

}
*/


