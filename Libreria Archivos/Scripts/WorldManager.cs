
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using EnemyAI;

namespace WorldControls
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class WorldManager : UdonSharpBehaviour
    {
        [Header("Monedas Mundo")]
        [SerializeField]
        public Coin[] Coins;

        [Header("Texto Monedas")]
        [SerializeField] private TextMeshPro coinText;

        //--------------------------------------------------
        [Header("Texto Tiempo")]
        private float timer;
        [SerializeField]
        private TextMeshPro firstMinute;
        [SerializeField]
        private TextMeshPro secondMinute;
        [SerializeField]
        private TextMeshPro separator;
        [SerializeField]
        private TextMeshPro firstSecond;
        [SerializeField]
        private TextMeshPro secondSecond;
        [SerializeField]
        private float timerDuration = 3f * 60f; //Duration of the timer in seconds
        [SerializeField]
        private bool countDown = true;
        private bool stopTime = false;
        //[Header("Texto Tiempo")]
        //[SerializeField] private TextMeshPro timeText;



        [Header("Teleports")]
        [SerializeField] private Transform StartSpot;
        [SerializeField] private Transform ResetSpot;
        [SerializeField] private Transform winSpot;

        [SerializeField] private GameObject prize;
        //[SerializeField] private Transform winSpot;
        [SerializeField] private Transform respawn;
        [SerializeField] public GameObject[] toggleObjects;

        [Header("Control Enemigo")]
        [SerializeField] public EnemyFollow EnemyIA;

        [Header("Play Start/Respawn/Win")]
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip audioClip1;
        [SerializeField] AudioClip audioClip2;
        [SerializeField] AudioClip audioClip3;
        [SerializeField] public int audioState;
        [HideInInspector] private bool audioSet;

        [HideInInspector]
        public bool _win = false;
        // public bool Win;

        void Start()
        {
            TimerReset();
            stopTime = false;
            EnemyIA.CurrentState = 4;
            _CoinUpdate();
        }

        private void Update()
        {
           /* if (!countDown && timer < timerDuration)
            {
                timer += Time.deltaTime;
                UpdateTimerDisplay(timer);
            }
            if(stopTime==true)
            {
                //timer = timer;
                UpdateTimerDisplay(timer);
            }
            */
        }

        public void _Reset()
        {
            audioSet = false;
            if (audioState != 1 && audioSet == false)
            {
                audioUpdate(1);
            }

            stopTime = false;
            TimerReset();
            foreach (var coin in Coins)
            {
                coin.Complete = false;
              

            }
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }

            //Debug.Log("Jugador ha reiniciado");
            Networking.LocalPlayer.TeleportTo(StartSpot.position, StartSpot.rotation);
            _CoinUpdate();
        }

        public void StartGame()
        {
            audioSet = false;
            if (audioState != 0 && audioSet == false)
            {
                audioUpdate(0);
            }
            stopTime = false;
            TimerReset();
            EnemyIA.CurrentState = 0;
            foreach (var coin in Coins)
            {
                coin.Complete = false;


            }
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(false);
            }

            //Debug.Log("Jugador ha iniciado");
            //var rotation = StartSpot.rotation;
            //var position = StartSpot.position;
            Networking.LocalPlayer.TeleportTo(StartSpot.position, StartSpot.rotation);
            //respawn.SetPositionAndRotation(position, rotation);
            _CoinUpdate();

        }

        public virtual void _EnemyState()
        {
           
            EnemyIA.CurrentState = 4;
            //Debug.Log("Estoy en el metodo _EnemyState() " + EnemyIA.CurrentState);
        }


        public virtual void _Win()
        {
            audioSet = false;
            if (audioState != 2 && audioSet == false)
            {
                audioUpdate(2);
            }

            stopTime = true;
            TimerStop();
            //Debug.Log("Estado ha cambiado a "+EnemyIA.CurrentState);
            // EnemyIA.CurrentState = 4;
            // Debug.Log("Estado ha cambiado a " + EnemyIA.CurrentState);
            foreach (GameObject obj in toggleObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
            Networking.LocalPlayer.TeleportTo(winSpot.position, winSpot.rotation);
            prize.SetActive(true);
           // var rotation = winSpot.rotation;
           // var position = winSpot.position;

            //Networking.LocalPlayer.TeleportTo(position, rotation);
           // respawn.SetPositionAndRotation(position, rotation);

           // _EnemyState();
            //EnemyIA.CurrentState = 4;


        }

        private void UpdateTimerDisplay(float time)
        {
            if (time < 0)
            {
                time = 0;
            }

            if (time > 3660)
            {
                Debug.LogError("Timer cannot display values above 3660 seconds");
                ErrorDisplay();
                return;
            }

            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            string currentTime = string.Format("{00:00}{01:00}", minutes, seconds);
            //coinText.text = $"Total Coins: {_coinCount}/{Coins.Length}";
            secondMinute.text = minutes.ToString();
            secondSecond.text = seconds.ToString();

            /*firstMinute.text = currentTime[0].ToString();
            secondMinute.text = currentTime[1].ToString();
            firstSecond.text = currentTime[2].ToString();
            secondSecond.text = currentTime[3].ToString();
            */

            //Use this for a single text object
            //timerText.text = currentTime.ToString();
        }
        private void ErrorDisplay()
        {
            firstMinute.text = "8";
            secondMinute.text = "8";
            firstSecond.text = "8";
            secondSecond.text = "8";


            //Use this for a single text object
            //timerText.text = "ERROR";
        }
        private void SetTextDisplay(bool enabled)
        {
            firstMinute.enabled = enabled;
            secondMinute.enabled = enabled;
            separator.enabled = enabled;
            firstSecond.enabled = enabled;
            secondSecond.enabled = enabled;

            //Use this for a single text object
            //timerText.enabled = enabled;
        }
        public void Timer()
        {


        }
        public void TimerReset()
        {
            if (countDown)
            {
                timer = timerDuration;
            }
            else
            {
                timer = 0;
            }
            SetTextDisplay(true);

        }
        public void TimerStop()
        {


        }


        public void audioUpdate(int var)
        {
            if (audioSource) audioSource.Stop();
            audioState = var;
            audioSource.loop = false;
            if (var == 0)
            {
                if (audioSource)
                {
                    audioSource.PlayOneShot(audioClip1);
                    audioSource.loop = true;
                }
            }
            if (var == 1)
            {
                if (audioSource)
                {
                    audioSource.PlayOneShot(audioClip2);
                    audioSource.loop = true;
                    /*
                    audioSource.clip = audioClip2;
                    audioSource.Play();
                    audioSource.loop = true;*/
                }
            }
            if (var == 2)
            {
                audioSource.PlayOneShot(audioClip3);
                audioSource.loop = true;

               
            }
            if (var == 3)
            {
                if (audioSource) audioSource.Stop();
            }
            if (var == 4)
            {
                if (audioSource) audioSource.Stop();
            }

            audioSet = true;
        }

        [HideInInspector]
        public int _coinCount = 0;
        public virtual void _CoinUpdate()
        {

            int count = 0;

            //Debug.Log("Cantidad de monedas a recolectar " + Coins.Length); 
            foreach (var coin in Coins)
            {
                if (coin.Complete == true)
                {
                    count++;
                    // coinText.text = $"Total Coins: {_coinCount}/{Coins.Length}";
                    //Debug.Log("se contaron " + count + "Monedas");
                }


            }

            if (count == Coins.Length)
            {
                //EnemyIA.CurrentState = 4;
                _Win();
                Debug.Log("Haz ganado!");

                //_win = true;

                // RequestSerialization();
            }
            else
            {
                //Debug.Log("Aun no se ah ganado " + count + "Monedas llevas");
            }

            _coinCount = count;
            coinText.text = $"Total Coins: {_coinCount}/{Coins.Length}";

        }



    }
}