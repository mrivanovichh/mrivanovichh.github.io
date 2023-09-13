using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;


namespace EnemyAI
{
    public class CallEnemy : UdonSharpBehaviour
    {

        [Header("Synced Fetchable Object")]
        [Tooltip("AI Controller reference")]
        public EnemyFollow AIController;

        void Start()
        {

        }

        public override void Interact()
        {
            AIController.CurrentState = 1;
            //AIController.CurrentState = 5;
        }

    }
}

