using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public MeshFilter Bleu;
    public MeshFilter Rouge;
    public MeshFilter Violet;
    public bool Half;
    public GameObject VaseVide;
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "BlueVase")
        {
            if (Half == true)
            {
                //VaseVide.GetComponent<MeshRenderer> ().material = Violet;
                Violet = VaseVide.GetComponent<MeshFilter>();
                Violet.sharedMesh = Resources.Load<Mesh>("Icosphere.003");
            }
            //VaseVide.GetComponent<MeshRenderer> ().material = Bleu;
            Bleu = VaseVide.GetComponent<MeshFilter>();
            Bleu.sharedMesh = Resources.Load<Mesh>("Icosphere.004");
            Half = true;
        }

        if (other.tag == "RedVase")
        {
            if (Half == true)
            {
                //VaseVide.GetComponent<MeshRenderer> ().material = Violet;
                Violet = VaseVide.GetComponent<MeshFilter>();
                Violet.sharedMesh = Resources.Load<Mesh>("Icosphere.003");
            }
            //VaseVide.GetComponent<MeshRenderer> ().material = Rouge;
            Rouge = VaseVide.GetComponent<MeshFilter>();
            Rouge.sharedMesh = Resources.Load<Mesh>("Icosphere.005");
            Half = true;
        }
    }

}