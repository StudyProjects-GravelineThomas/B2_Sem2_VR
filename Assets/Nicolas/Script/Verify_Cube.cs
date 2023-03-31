using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verify_Cube : MonoBehaviour
{
    public string Cube1; //CubeRouge
    public string Cube2; //CubeVert
    public string Cube3; //CubeJaune
    public string Cube4; //CubeBleu
    public string Cube5; //Cube
    public GameObject ClosedDoor;   
    public GameObject OpenedDoor;

    void Start()
    {
        //Nbr = CombinationManager.GetComponent<SetNumber>();
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == Cube1 || other.tag == Cube2 || other.tag == Cube3 || other.tag == Cube4 || other.tag == Cube5)
        {
            //CombinationManager.GetComponent<SetNumber>().SetNumberPlus();
            ClosedDoor.SetActive(false);
            OpenedDoor.SetActive(true);

            AudioManager.instance.PlaySound("DoorUnlock");
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == Cube1 || other.tag == Cube2 || other.tag == Cube3 || other.tag == Cube4 || other.tag == Cube5)
        {
            //CombinationManager.GetComponent<SetNumber>().SetNumberMinus();
            ClosedDoor.SetActive(true);
            OpenedDoor.SetActive(false);

            AudioManager.instance.PlaySound("DoorUnlock");
        }  
    }
}
