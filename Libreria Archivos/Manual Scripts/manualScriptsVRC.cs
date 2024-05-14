
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class manualScriptsVRC : UdonSharpBehaviour
{
    void Start()
    {

    }
}

namespace ManualdeReferencia {

    /*//Player Related methods
    public override void OnPlayerJoined(VRCPlayerApi player) { }
    public override void OnPlayerLeft(VRCPlayerApi player) { }
    public override void OnPlayerTriggerEnter(VRCPlayerApi player) { }
    public override void OnPlayerTriggerStay(VRCPlayerApi player) { }
    public override void OnPlayerTriggerExit(VRCPlayerApi player) { }
    public override void OnPlayerCollisionEnter(VRCPlayerApi player) { }
    public override void OnPlayerCollisionStay(VRCPlayerApi player) { }
    public override void OnPlayerCollisionExit(VRCPlayerApi player) { }
    public override void OnPlayerParticleCollision(VRCPlayerApi player) { }
    public override void OnPlayerRespawn(VRCPlayerApi player) { }
    //PlayerVariables
    var localPlayer = Networking.LocalPlayer;
    var flag = Networking.IsOwner(TargetGameobject);
    */

    /*//Pickup Related Methods
    public override void OnPickup() { }
    public override void OnPickupUseDown() { }
    public override void OnPickupUseUp() { }
    public override void OnDrop() { }
    //Button on Interact Related Methods
    public override void Interact() { }
    //Related to the game Object
    void OnEnable() { }
    void OnDisable() { }
    public override void OnSpawn() { }
    void OnDestroy() { }
    */

    #region Keydowns General
    //KeyDowns General-------------------------------//

    /* Ejemplo KeyDown
     void Update()
     {
     //replace KeyCode
         if (Input.GetKeyDown(//"KeyCode"//)) { }
     }
         void Update()
     {
         if(Input.GetKeyUp(KeyCode)) { }
     }
     */

    //Direct Functions
    /*Informacion de inputs
     For the input system, the following information applies to all.

value : A variable that indicates either args.boolValue or args.floatValue information according to the input value.
args.eventType: Variable to output whether the input medium is BUTTON or AXIS
args.boolValue: A variable that indicates the input value of bool
args.floatValue: Variable indicating the input value of float
args.handType: Variable that outputs right hand or left hand for VR , keyboard as left hand and mouse as right hand for desktop

On the other hand, the following information applies to the MIdi system.

channel: Variable indicating the acquired Midi channel
number: Variable indicating the acquired Note number from 0 to 127
velocity: A variable that indicates the strength and speed of the acquired MidiNote.
value : Variable indicating the value output from the acquired controller*/
    /*Metodos Directos Jump, use, etc
    public override void InputJump(bool value, UdonInputEventArgs args) { }
    public override void InputUse(bool value, UdonInputEventArgs args) { }
    public override void InputGrab(bool value, UdonInputEventArgs args) { }
    public override void InputDrop(bool value, UdonInputEventArgs args) { }
    public override void InputMoveHorizontal(float value, UdonInputEventArgs args) { }
    public override void InputMoveVertical(float value, UdonInputEventArgs args) { }
    public override void InputLookHorizontal(float value, UdonInputEventArgs args { }
    public override void InputLookVertical(float value, UdonInputEventArgs args) { }
    */
    //KeyDowns End-------------------------------//
    #endregion

    /*//Haptics
    Networking.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Left, 0, 0, 0);
    Networking.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right, 0, 0, 0);
    */

    /*//Midi note
    public override void MidiNoteOn(int channel, int number, int velocity) { }
    public override void MidiNoteOff(int channel, int number, int velocity) { }
    public override void MidiControlChange(int channel, int number, int value) { }
    */

    /*  //Chairs
    public override void OnStationEntered() { }
    public override void OnStationExited() { }
*/

    /*//Particles
    void OnParticleCollision(GameObject other) { }
    */

    /*//Triggers
    void OnTriggerEnter(Collider other) { }
    void OnTriggerEnter2D(Collider2D other) { }
    void OnTriggerStay(Collider other) { }
    void OnTriggerStay2D(Collider2D other) { }
    void OnTriggerExit(Collider other) { }
    void OnTriggerExit2D(Collider2D other) { }
    */

    /*//Coliders
    void OnCollisionEnter(Collision other) { }
    void OnCollisionEnter2D(Collision2D other) { }
    void OnCollisionStay(Collision other) { }
    void OnCollisionStay2D(Collision2D other) { }
    void OnCollisionExit(Collision other) { }
    void OnCollisionExit2D(Collision2D other) { }
    */

    /*  //UI
    private VRC.SDK3.Components.VRCUrlInputField _inputfield;
    */

    /* //VideoPlayer
    public override void OnVideoReady() { }
    public override void OnVideoStart() { }
    public override void OnVideoPlay() { }
    public override void OnVideoPause() { }
    public override void OnVideoLoop() { }
    public override void OnVideoError(VideoError videoError) { }
    private VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer _videoPlayer;
    */

    /*//Acomodar
    public void FlagDiscontinuity();
    public void Respawn();
    public void SetGravity(bool value);
    public void SetKinematic(bool value);
    public void TeleportTo(Transform targetLocation);//Metodo mas util para mover objetos 
    */

    /*//Networking

    //owner
    public override void OnOwnershipTransferred() { }

    public override void OnPreSerialization() { }
    public override void OnPostSerialization() { }//TLX FSP reference
    public override void OnDeserialization() { }//dentro de aqui usar _HandleSerialization
    public override void PostLateUpdate() { }

    private void _HandleSerialization() { }

    //"FunctionName" = nameof(myCoolEvent)
    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "FunctionName");
    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "FunctionName");

    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(ejemploEvento));
    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, nameof(ejemploEvento));


    [RecursiveMethod]//ejemplo recursividad
                     //private type function name {}

    [UdonSynced(UdonSyncMode.None)] //old ignore
    [UdonSynced(UdonSyncMode.Linear)] //old ignore
    [UdonSynced(UdonSyncMode.Smooth)] //old ignore
    [UdonSynced(UdonSyncMode.NotSynced)] //old ignore

    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]


    [UdonSynced]
    private interface favouriteNumber;

    public void SetFavoriteNumber(int num)
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        favouriteNumber = num;

        RequestSerialization();//usar estos dos
        _HandleSerialization();//en conjuto siempre que se pueda
    }
    */

    /*Ejemplo de Networking pool
      //--------------------------Ejemplo de Networking pool-----------------------------------------//
    Network.SetFavoriteNumber(int num)
    {
        ing.SetOwner(Networking.LocalPlayer, gameObject);
        GameObject poolObject = pool.TryToSpawn();
        if (!poolObject)
        {
            return;
        }
    }

    if(controller.ownerName==player.displayName){
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        pool.Return(obj);
    }
    //--------------------------------------------------------------------------------------------//
    */

    /*Ejemplo para solo lanzar eventos a los jugadore late joiners  
       //-------------------Ejemplo para solo lanzar eventos a los jugadore late joiners-------------//
                [UdonSynced]          
                private interface activatedTime;
                public override void Interact()
          {
                  Networking.SetOwner(Networking.LocalPlayer, gameObject);
                  activatedTime = Networking.GetServerTimeInMilliseconds();
                  Trigger();
                  RequestSerialization();

          }
                  public override void OnDeserialization() {
                    if(Networking.GetServerTimeInMilliseconds() - activatedTime > 2000) { return; }

                         Trigger();
                            }
          //--------------------------------------------------------------------------------------------//
  */



}
