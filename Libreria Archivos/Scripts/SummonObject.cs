
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
namespace InstanciasObjetos
{
    public class SummonObject : UdonSharpBehaviour
    {
        public GameObject obj;
        public Transform posRef;
        private GameObject find;
        private int count;
        public override void Interact()
        {
            SpawnObj();
            count++;
            Debug.Log("Contador actualy "+ count);
        }

        public void SpawnObj()
        {
            var newObject = VRCInstantiate(obj);
            newObject.transform.position = posRef.position;
            
            //Destroy(newObject, 2);

        }

        public void DestroyObj()
        {
            find = GameObject.Find("SummonTest(Clone)");
            Destroy(find);

            /*bool i = true;
            if (count >= 0) { 

                while(i==true){
                Debug.Log("Contador restando " + count);
                // Debug.Log("Se ejecuto destroy");
                find = GameObject.Find("SummonTest(Clone)");

                //Debug.Log(find.name);
                Destroy(find);
                    Debug.Log("Se ejecuto destroy");
                    count--;
                 }
            }
            else
            {
                i = false;
                count = 0;
                

            }*/









            /*
            for (int i = 0; i <= count; i++){
                Debug.Log("Contador restando " + count);
                // Debug.Log("Se ejecuto destroy");
                find = GameObject.Find("SummonTest(Clone)");

                //Debug.Log(find.name);
                Destroy(find);

            }*/



        }

    }
}


/*
 
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DestroyObject : UdonSharpBehaviour
{
    public GameObject obj;
    //public VRC_Pickup pelota;

    public override void Interact()
    {
       // DestroyObj();

    }
    public void DestroyObj()
    {
        //GameObject.Destroy(obj);
    }
}

     */
