
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

namespace Player.Detector{
    public class PlayerDetector : UdonSharpBehaviour
    {

        public int players = 0;
        public Text num;

        void Start()
        {
            players = 0;
        }

        public virtual void RefreshPlayerCounter()
        {
            num.text = (players).ToString();
            Debug.Log(players+"Jugadores dentro");
        }


        public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
        {
            players++;
            RefreshPlayerCounter();
        }

        public virtual void OnPlayerTriggerExit(VRC.SDKBase.VRCPlayerApi player)
        {
            players--;
            RefreshPlayerCounter();
        }

    }

}
