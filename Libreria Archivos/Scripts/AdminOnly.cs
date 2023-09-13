using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class AdminOnly : UdonSharpBehaviour
{
    [SerializeField] private string[] admins;
    void Start()
     //private string "mrivanovichh";

        

    {
        bool isAdmin = false;
        foreach (string admin in admins)
        {
            if (Networking.LocalPlayer.displayName == admin)
            {
                isAdmin = true;
            }
        }

        if (!isAdmin)
        {
            Destroy(gameObject);
            return;
        }
        Destroy(this);
    }
}
