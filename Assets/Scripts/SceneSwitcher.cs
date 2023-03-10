using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    
    [SerializeField] private Collider Collider;
    [SerializeField] private string SceneName;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            SceneManager.instance.LoadScene(SceneName);
        }
    }

}
