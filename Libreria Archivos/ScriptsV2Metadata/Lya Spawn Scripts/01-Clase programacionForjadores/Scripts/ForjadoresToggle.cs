
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;


//en Steam agregar esto en GENERAL para activar el modo debug en VRCHAT
//--enabke-debug-gui
//Shift derecho+sibolo de grados°+numeros del 1 al 7
//Shift+°+1-7
//En debug  el amster es color Verde



//DECLARACION SI EL SCRIPT VA MANUAL/CONTINUOS/NONE
[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class ForjadoresToggle : UdonSharpBehaviour
{
    //Libreria de ejemplos de Codigo

    //Declaracion de variables
    //Variable declarada
    public bool zapatillaA;
    //Variable Inicializada
    public bool zapatillaB = false;
    public bool zapatillaC = true;
    public bool zapatillaD;

    public int basuraA;
    public int basuraB = 2;


    public float manzanaA;
    public float manzanaB = 5.5f;

    public string textoA;
    public GameObject ejemploGameObjectA;
    public GameObject[] ejemploGameObjectB;
    public GameObject[] ejemploGameObjectC;

    public Component componenteA;
    public Transform vectorA;
    public Collider colliderA;



    //UDON

    [UdonSynced]
    bool isEnabled;





    //Metodo de inicio 
    void Start()
    {
        zapatillaD = zapatillaC;
    }


    public override void Interact()
    {
       
        //Una accion
        //ejemploGameObjectA.SetActive(false);

        //Un toggle La accion de !ejemplo es una accion de INVERTIR-arroja el valor contrario-
        ejemploGameObjectA.SetActive(!ejemploGameObjectA.activeSelf);



        //
        if (!Networking.IsOwner(gameObject))
            Networking.SetOwner(Networking.LocalPlayer, gameObject);

        isEnabled = !isEnabled;
        //toggleObject.SetActive(isEnabled);

        RequestSerialization();






    }

    


}
