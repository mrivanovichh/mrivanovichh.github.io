using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using EnemyAI;
using WorldControls;

public class ResetGame : UdonSharpBehaviour
{

    public EnemyFollow AIController;
    public WorldManager Coins;

    void Start()
    {
        
    }

    public override void Interact()
    {


        AIController.CurrentState = 0;
        Coins._coinCount = 0 ;
        Coins._win = false;
        Coins._Reset();
       

    }

}
