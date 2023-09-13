
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ExitTriggerSwitch : UdonSharpBehaviour
{
    [Header("Toggle Objects")]
    [SerializeField] GameObject[] toggleObjects;
    [SerializeField] Simple_Toggle[] tglBTN;
    public bool clear = true;

    void Start()
    {
        
    }
    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        
    }

    public virtual void OnPlayerTriggerExit(VRC.SDKBase.VRCPlayerApi player)
    {
      

        if (player.isLocal)
        {
            if (!player.isLocal) return;
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(false);

            }


        }


        foreach (Simple_Toggle TLG in tglBTN)
        {
         //   TLG.(false);
            //TLG.isActiveAndEnabled(false);

        }
        //if (animator) animator.StopPlayback();

        /*
         * 
         *  public void Teleport_click()
    {
        Networking.LocalPlayer.TeleportTo(teleportPoint.position, teleportPoint.rotation, teleportOrientation, lerpOnRemote);
    }
}







          if (player.isLocal && !clear)
        {
            clear = true;
        }




        */

    }
}
