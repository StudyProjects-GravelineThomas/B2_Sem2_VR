using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyTag : MonoBehaviour
{
    public string IsTag;
    public string Tag1;
    public string Tag2;
    public string Tag3;
    public GameObject ClosedDoor;
    public GameObject OpenedDoor;
    //public GameObject AntiTP;
    public GameObject CombinationManager;
    private SetNumber Nbr;
    //public bool IsSpecialDoor = false;
    void Start()
    {
        Nbr = CombinationManager.GetComponent<SetNumber>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == IsTag)
        {
            if (IsTag == Tag1 || IsTag == Tag2 || IsTag == Tag3)
            {
                CombinationManager.GetComponent<SetNumber>().SetNumberPlus();
                if (Nbr.Number >= 3)
                {
                    ClosedDoor.SetActive(false);
                    OpenedDoor.SetActive(true);
                    GetComponent<Send_Luminous>().Send_Lumi();
                    AudioManager.instance.PlaySound("DoorUnlock");
                }
            }
            else
            {
                ClosedDoor.SetActive(false);
                OpenedDoor.SetActive(true);
                GetComponent<Send_Luminous>().Send_Lumi();
                /*if(IsSpecialDoor == true)
                {
                    AntiTP.SetActive(false);
                }*/
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == IsTag)
        {
            if (IsTag == Tag1 || IsTag == Tag2 || IsTag == Tag3)
            {
                CombinationManager.GetComponent<SetNumber>().SetNumberMinus();
                if (Nbr.Number == 2)
                {
                    ClosedDoor.SetActive(true);
                    OpenedDoor.SetActive(false);
                }
            }
            else
            {
                ClosedDoor.SetActive(true);
                OpenedDoor.SetActive(false);
            }

        }
    }
}

