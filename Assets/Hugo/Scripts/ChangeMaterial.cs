using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject Bleu;
    public GameObject Rouge;
    public GameObject Violet;
    public bool Half;
    public bool Done = true;
    public GameObject VaseVide;
    
    void OnTriggerEnter(Collider other)
    {
        if (Done == false)
        {
            if (other.tag == "BlueVase")
            {
                if (Half == true)
                {
                    Violet.SetActive(true);
                    /*VaseVide.GetComponent<MeshRenderer>().material = Violet;
                    Violet = VaseVide.GetComponent<MeshFilter>();
                    Violet.sharedMesh = Resources.Load<Mesh>("Icosphere,003");*/
                }
                else
                {
                    Bleu.SetActive(true);
                    VaseVide.SetActive(false);
                    /*VaseVide.GetComponent<MeshRenderer> ().material = Bleu;
                    Bleu = VaseVide.GetComponent<MeshFilter>();
                    Bleu.sharedMesh = Resources.Load<Mesh>("Icosphere,004");*/
                    Half = true;
                }
                
            }

            if (other.tag == "RedVase")
            {
                if (Half == true)
                {
                    Violet.SetActive(true);
                    /*VaseVide.GetComponent<MeshRenderer> ().material = Violet;
                    Violet = VaseVide.GetComponent<MeshFilter>();
                    Violet.sharedMesh = Resources.Load<Mesh>("Icosphere,003");*/
                }
                else
                {
                    Rouge.SetActive(true);
                    VaseVide.SetActive(false);
                    /*VaseVide.GetComponent<MeshRenderer> ().material = Rouge;
                    Rouge = VaseVide.GetComponent<MeshFilter>();    
                    Rouge.sharedMesh = Resources.Load<Mesh>("Icosphere,005");*/
                    Half = true;
                }
               
            }
        } 
    }
}