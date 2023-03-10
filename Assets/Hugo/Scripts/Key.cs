using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LuminousManager;

    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Hand")
        {
            LuminousManager.GetComponent<Luminous>().LuminousProtocol();
        }
    }

}
