using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LuminousManager;
    public GameObject OpenedDoor;
    public GameObject ClosedDoor;
    public GameObject AntiTP;

    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Hand")
        {
            LuminousManager.GetComponent<Luminous>().Luminous_Key();
        }

        if (other.tag == "SpecialDoor")
        {
            ClosedDoor.SetActive(false);
            OpenedDoor.SetActive(true);
            AntiTP.SetActive(false);
        }
    }

}
