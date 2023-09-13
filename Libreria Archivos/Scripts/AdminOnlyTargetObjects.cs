using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class AdminOnlyTargetObjects : UdonSharpBehaviour
{
    [SerializeField] private string[] admins;
    [SerializeField] public GameObject[] destroyObjects;
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
            foreach (GameObject obj in destroyObjects)
            {
                Destroy(obj);
               
            }

            
            return;
        }
        //Destroy(this);
    }
}
