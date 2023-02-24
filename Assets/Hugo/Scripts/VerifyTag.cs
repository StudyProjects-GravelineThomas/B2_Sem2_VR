using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyTag : MonoBehaviour
{
    public string IsTag;
    public GameObject ClosedDoor;   
    public GameObject OpenedDoor;
    public GameObject CombinationManager;
    private SetNumber Nbr;
    void Start()
    {
        Nbr = CombinationManager.GetComponent<SetNumber>();
    }
    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == IsTag)
        {
            if(IsTag == "Skull" || IsTag == "Pail" || IsTag == "Vase")
            {
                CombinationManager.GetComponent<SetNumber>().SetNumberPlus();
                //Debug.Log("+1");
                if(Nbr.Number >= 3)
                {
                    ClosedDoor.SetActive(false);
                    OpenedDoor.SetActive(true);
                    //Debug.Log("Ouvre");
                }
            }
            else
            {
                ClosedDoor.SetActive(false);
                OpenedDoor.SetActive(true);
                //Debug.Log("OuvreAutre");
            } 
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == IsTag)
        {
            if(IsTag == "Skull" || IsTag == "Pail" || IsTag == "Vase")
            {
                CombinationManager.GetComponent<SetNumber>().SetNumberMinus();
                //Debug.Log("-1");
                if(Nbr.Number == 2)
                {
                    ClosedDoor.SetActive(true);
                    OpenedDoor.SetActive(false);
                    //Debug.Log("Ferme");
                }
            }
            else
            {
                ClosedDoor.SetActive(true);
                OpenedDoor.SetActive(false);
                //Debug.Log("FermeAutre");
            }
            
        }
    }
}
