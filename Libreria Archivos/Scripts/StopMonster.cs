
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using EnemyAI;
using WorldControls;

public class StopMonster : UdonSharpBehaviour
{
    public EnemyFollow AIController;
    [SerializeField] bool localOnly;

    //public WorldManager Coins;

    /*  void Start()
      {

          AIController.CurrentState = 4;
          //Coins._coinCount = 0;
        //  Coins._win = false;
       //   Coins.StartGame();

      }

      */

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (localOnly && !player.isLocal) return;

        AIController.CurrentState = 4;

    }


}
