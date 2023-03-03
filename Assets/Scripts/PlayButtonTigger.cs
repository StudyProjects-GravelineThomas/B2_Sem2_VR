using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonTigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "RightHand")
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Menu");
        }
    }
}
