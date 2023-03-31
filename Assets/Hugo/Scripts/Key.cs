using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LuminousManager;
    public GameObject OpenedDoor;
    public GameObject ClosedDoor;
    public bool AlreadyDone;

    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Hand")
        {
            if(AlreadyDone == false)
            {
                LuminousManager.GetComponent<Luminous>().Luminous_Key();
                AlreadyDone = true;
            }
        }

        if (other.tag == "SpecialDoor")
        {
            ClosedDoor.SetActive(false);
            OpenedDoor.SetActive(true);
            AudioManager.instance.PlaySound("DoorUnlock");
        }
    }

}
