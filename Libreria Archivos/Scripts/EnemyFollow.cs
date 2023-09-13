using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDKBase;
using VRC.Udon;

namespace EnemyAI
{

    public class EnemyFollow : UdonSharpBehaviour
    {
        [Header("Enemy Config")]
        public NavMeshAgent navagent;
        public int CurrentState;
        [Tooltip("This is how long the AI will wait once it reaches it's new position while wandering!")]
        public float WanderIdleTime = 5f;
        public float MaxWanderDistance = 5f;

        private VRCPlayerApi TargetPlayer; // The PlayerApi of the target player. For local AIs, this will always be the local player!
        private Vector3 CurrentDestination;
        private bool IsMovingToNext; // Checking if the AI is in the process of moving to the next waypoint
        private bool HasSetNextPosition; // Used for checking if a new position has been generated
        private float InternalWaitTime; // Wandering idle wait time internal counter

        [Header("Enemy Speed Wander")]
        public int speedWander=5;
        public int accelerationWander=5;

        [Header("Enemy SpeedAgro")]
        public int speedAgro = 10;
        public int accelerationAgro = 10;

        [Header("Wandering Points")]
        public Transform[] Waypoints;
        public int waypointSelector;
        public int indexWay = 0;

        [Header("Wandering Points Random")]
        public int min;
        public int max;
        int moveState;
        float timer = 10f;

        [Header("Play Calm/Chase")]
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip audioClip1;
        [SerializeField] AudioClip audioClip2;
        [SerializeField] public int audioState;
        [HideInInspector] private bool audioSet;

        [Header("Pickup pet")]
        public Transform followTarget;

        void Start()
        {
            navagent = GetComponent<NavMeshAgent>();

            TargetPlayer = Networking.LocalPlayer;
            CurrentState = 4;
            waypointSelector = Waypoints.Length;
            //Debug.Log("Hay "+waypointSelector+" Puntos");
        }
        private void Update()
        {

            //Enemigo camina en orden por puntos
            if (CurrentState == 0)
            {
                navagent.enabled = true;
                Debug.Log("Enemigo estado " + CurrentState);
                audioSet = false;
                if (audioState != 0 && audioSet == false)
                {
                    audioUpdate(0);
                }

                
                navagent.speed = speedWander;
                navagent.acceleration = accelerationWander;
                /*int WP=0;
                WP=Waypoints.Length;
                Debug.Log("Hay " + WP + "Puntos en el mapa");
                */
                //Debug.Log("Enemigo esta en punto "+ indexWay);
                //navagent.SetDestination(Waypoints[indexWay].position);



                //Debug.Log("Segundos para que el enemigo se mueva " + InternalWaitTime);
                navagent.SetDestination(Waypoints[indexWay].position);

                //Debug.Log("Enemigo esta en movimiento a " + indexWay);
                if (navagent.remainingDistance <= navagent.stoppingDistance)
                {
                    InternalWaitTime -= Time.deltaTime;
                   //Debug.Log("Enemigo esta esperando a moverse a  " + indexWay);
                    if (InternalWaitTime <= 0)
                    {
                        InternalWaitTime = WanderIdleTime;

                        indexWay++;

                        if (indexWay >= Waypoints.Length) { indexWay = 0; Debug.Log("---Se reinicio el Index a 0---"); }

                        //Debug.Log("Se reinicio el tiempo local");
                        //Debug.Log("Se suma uno al idex " + indexWay);
                        //Debug.Log("Se  asigno La trayectoria a punto " + indexWay);


                    }
                }
            }
            //Enemigo Sigue a jugador
            if (CurrentState == 1)
            {
                Debug.Log("Enemigo estado " + CurrentState);
                audioSet = false;
                if (audioState != 1 && audioSet == false)
                {
                    audioUpdate(1);
                }

                navagent.speed = speedAgro;
                navagent.acceleration = accelerationAgro;
                navagent.SetDestination(TargetPlayer.GetPosition());
            }
            //Enemigo Camina Random
            if (CurrentState == 2)
            {
                Debug.Log("Enemigo estado " + CurrentState);
                audioSet = false;
                if (audioState != 2 && audioSet == false)
                {
                    audioUpdate(2);
                }

               
                // Feed AI info into the animator
                //AIAnimator.SetFloat("Velocity", Agent.velocity.magnitude);
                //AIAnimator.SetBool("IsJumping", Agent.isOnOffMeshLink);

                if (!IsMovingToNext) // Runs while the AI is idle
                {
                    HasSetNextPosition = false;

                    InternalWaitTime -= Time.deltaTime;

                    if (InternalWaitTime < 0f)
                    {
                        IsMovingToNext = true;

                        InternalWaitTime = WanderIdleTime;

                        StartWandering(); // Starts wandering once the idle timer has ended!

                        //SendCustomEventDelayedSeconds(nameof(StartWandering), WanderIdleTime); Alternative to an internal timer
                    }
                }

                if (navagent.remainingDistance < 1 // | Remaining distance must always be greater than the stopping distance!
                    && HasSetNextPosition) //Makes sure a new position has been set!
                {
                    IsMovingToNext = false;

                    InternalWaitTime = WanderIdleTime;
                }

            }

            if (CurrentState == 4)
            {

                navagent.speed = 0;
                navagent.acceleration = 1;
                Debug.Log("Enemigo esta Detenido en estado " + CurrentState);
                audioSet = false;
                if (audioState != 4 && audioSet==false)
                {

                    audioUpdate(4);
                    
                }

                navagent.enabled=false;

            }
                #region estado de caminar a pundo aleatorios disque
                //Estado Camina entre Puntos Clave Aleatoriamente
                /* if (CurrentState == 3)
                 {
                     max = 3;
                     moveState = CalculateRandom();
                     max = moveState;
                     Debug.Log("Resultado Rango Random " + moveState);

                     if (!IsMovingToNext)
                     {
                         if (moveState == 1)
                         {
                             HasSetNextPosition = false;

                             Debug.Log("Enemigo va a punto 1");

                             InternalWaitTime -= Time.deltaTime;
                             if (InternalWaitTime < 0f)
                             {
                                 Debug.Log("ESPERA EN PUNTO 1");
                                 IsMovingToNext = true;
                                 navagent.SetDestination(followTarget1.position);
                                 followTarget1.hasChanged = false;
                                 InternalWaitTime = WanderIdleTime;
                                 Debug.Log("TIEMPO EN PUNTO 1" + InternalWaitTime);

                             }
                         }
                         if (moveState == 2)
                         {
                             HasSetNextPosition = false;

                             Debug.Log("Enemigo va a punto 2");

                             InternalWaitTime -= Time.deltaTime;
                             if (InternalWaitTime < 0f)
                             {
                                 Debug.Log("ESPERA EN PUNTO 2");
                                 IsMovingToNext = true;
                                 navagent.SetDestination(followTarget2.position);
                                 followTarget2.hasChanged = false;
                                 InternalWaitTime = WanderIdleTime;
                                 Debug.Log("TIEMPO EN PUNTO 2" + InternalWaitTime);


                             }
                         }
                     }

                     //Remaining distance must always be greater than the stopping distance!
                     //Makes sure a new position has been set!

                     if (HasSetNextPosition == true)
                     {
                         Debug.Log("Reinicio de Puntos");
                         IsMovingToNext = false;

                         InternalWaitTime = WanderIdleTime;
                     }

                 }
                 */
                #endregion

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
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                    audioSource.loop = true;
                }
            }
            if (var == 1)
            {
                if (audioSource) {
                    audioSource.clip = audioClip2;
                    audioSource.Play();
                    audioSource.loop = true;
                }
            }
            if (var == 2)
            {
                if (audioSource) audioSource.Stop();
            }
            if (var == 3)
            {
                if (audioSource) audioSource.Stop();
            }
            if (var == 4) {
                if (audioSource) audioSource.Stop();
            }

            audioSet = true;
        }
            public void WanderSpots()
            {
                Debug.Log("Se activo WanderSpots en metodo");

                Debug.Log("Siguiente posicion en WANDERSPOTS " + HasSetNextPosition);

                moveState = CalculateRandom();
                Debug.Log("Resultado Rango Random " + moveState);



            }

            public void WaypointsWander(int way)
            {
            int temp = way;
                //Debug.Log("Enemigo va a punto " + temp);

                navagent.SetDestination(Waypoints[temp].position);

            //navagent.SetDestination(followTarget1.position);

            //Waypoints[way].hasChanged = false;





            }

            public void Wander()
            {
                if (!IsMovingToNext) // Runs while the AI is idle
                {
                    HasSetNextPosition = false;

                    InternalWaitTime -= Time.deltaTime;

                    if (InternalWaitTime < 0f)
                    {
                        IsMovingToNext = true;

                        InternalWaitTime = WanderIdleTime;

                        StartWandering(); // Starts wandering once the idle timer has ended!

                        //SendCustomEventDelayedSeconds(nameof(StartWandering), WanderIdleTime); Alternative to an internal timer
                    }
                }

                if (navagent.remainingDistance < 1 // | Remaining distance must always be greater than the stopping distance!
                    && HasSetNextPosition) //Makes sure a new position has been set!
                {
                    IsMovingToNext = false;

                    InternalWaitTime = WanderIdleTime;
                }
            }

            public void StartWandering() // Function used to force the AI to find a new random position!
            {
                SetAIDestination(CalculateRandomPosition(MaxWanderDistance));
            }

            public void SetAIDestination(Vector3 Target) // Used for setting the AI's next destination!
            {
                HasSetNextPosition = true;
                CurrentDestination = Target;

                navagent.SetDestination(CurrentDestination);
            }

            public int CalculateRandom() // Calculates a navmesh position within specific distance constraints!
            {
                HasSetNextPosition = true;
                int randCal = Random.Range(min, max);

                return randCal;
            }

            private Vector3 CalculateRandomPosition(float dist) // Calculates a navmesh position within specific distance constraints!
            {
                var randDir = transform.position + Random.insideUnitSphere * dist; // Finds a point within a 3D space around the AI!

                NavMeshHit hit;

                NavMesh.SamplePosition(randDir, out hit, dist, NavMesh.AllAreas); // Uses the calculated point to find the nearest navmesh position!

                return hit.position;
            }

            /*private Vector3 WaypointPosition(float dist){
            var tra = transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(tra, out hit, dist, NavMesh.AllAreas);
        }*/


        }



    }


