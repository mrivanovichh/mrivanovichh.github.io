
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


public class JoinLeaveBell : UdonSharpBehaviour
{
    public AudioSource bell;
    public AudioSource bell2;
    public bool oneshot = false;
    public bool networked = false;

    void Start()
    {
        if (networked)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "Joined");
        }
    }

    public virtual void OnPlayerJoined(VRC.SDKBase.VRCPlayerApi player)
    {
        if (!networked)
        {
            Joined();
            Debug.Log("1");
        } 
    }

    public virtual void OnPlayerLeft(VRC.SDKBase.VRCPlayerApi player)
    {
        if (!networked)
        {
            Leave();
            Debug.Log("2");
        }
    }


    public void Joined()
    {
        if (oneshot)
        {
            bell.PlayOneShot(bell.clip, bell.volume);
        }
        else
        {
            bell.Play();
        }
    }


    public void Leave()
    {
        if (oneshot)
        {
            bell2.PlayOneShot(bell2.clip, bell2.volume);
        }
        else
        {
            bell2.Play();
        }
    }

}
