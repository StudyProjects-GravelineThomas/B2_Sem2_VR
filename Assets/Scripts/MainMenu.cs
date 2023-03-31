using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Menu");
        AudioManager.instance.PlaySoundAfter("One_01", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
