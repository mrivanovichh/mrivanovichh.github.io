
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class UsersInTrigger : UdonSharpBehaviour
{
    public VRCPlayerApi[] userList;

    //Variable para jugadores dentro del tirgger
    string[] PlayersLists = new string[82];

    //Ejemplo Simple
    public Text playerTrigg;
    public Text DisplayCont;
    int ContDisp = 0;

    // Text jugadorDisplay;
    //Text numberDisplay;
    //public string playerformat = "{Name}";
    public GameObject Trigger;
    public AudioSource audioSource;
    public AudioClip audioClip;



    void Start()
    {

    }


    public void RefreshTextList()
    {
        DisplayCont.text = ContDisp.ToString();
        //DisplayCont.text = PlayersLists.Length.ToString();

        //Dispaly de Nombre
        playerTrigg.text = string.Empty;
        for (int i = 0; i <= PlayersLists.Length - 1; i++)
        {
            if (!string.IsNullOrEmpty(PlayersLists[i]))
            {
                playerTrigg.text = playerTrigg.text + PlayersLists[i] + "\n";
               // Debug.Log("Listado"+PlayersLists[i]);
                
            }
        }
    }



    public void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        // player.
        //Sonido para probar que funcione el trigger
        audioSource.PlayOneShot(audioClip);

        //Muestra el Jugador Dentro
        // playerTrigg.text = player.displayName;

        ContDisp++;
        for (int i = 0; i <= PlayersLists.Length - 1; i++)
        {
            //if (PlayersLists[i] == string.Empty)
            if (string.IsNullOrEmpty(PlayersLists[i]))
            {
                PlayersLists[i] = player.displayName;
                break;
            }
        }

        RefreshTextList();
    }

    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        //Sonido para probar que funcione el trigger
        audioSource.PlayOneShot(audioClip);

        //Borrar el chat
        //playerTrigg.text = null;
        ContDisp--;
        for (int i = 0; i <= PlayersLists.Length - 1; i++)
        {
            //if (PlayersLists[i] == player.displayName)
            if (PlayersLists[i].Equals(player.displayName))
            {
                PlayersLists[i] = string.Empty;
                break;
            }
        }

        RefreshTextList();
    }

   




}
