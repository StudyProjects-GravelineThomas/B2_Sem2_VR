using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject Porte;   
    public GameObject PorteOuverte;
    public GameObject SceneSwitcher;
    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Crate")
        {
            Porte.SetActive(false);
            PorteOuverte.SetActive(true);
            SceneSwitcher.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Crate")
        {
            Porte.SetActive(true);
            PorteOuverte.SetActive(false);
            SceneSwitcher.SetActive(false);
        }
    }
}
