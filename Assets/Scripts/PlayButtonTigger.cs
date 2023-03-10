using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonTigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PlayButtonTigger.OnTriggerEnter(" + other.name + ")");
        if(other.tag == "Player")
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("ButtonClick");
            GameObject.Find("SceneManager").GetComponent<SceneManager>().LoadScene("Hugo_Lvl1");
        }
    }
}
