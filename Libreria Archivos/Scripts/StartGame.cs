using UnityEngine.AI;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using EnemyAI;
using WorldControls;

public class StartGame : UdonSharpBehaviour
{
    public EnemyFollow AIController;
    public WorldManager Coins;
    void Start()
    {
        
    }

    public override void Interact()
    {


        AIController.CurrentState = 0;
        Coins._coinCount = 0;
        Coins._win = false;
        Coins.StartGame();


    }

}
