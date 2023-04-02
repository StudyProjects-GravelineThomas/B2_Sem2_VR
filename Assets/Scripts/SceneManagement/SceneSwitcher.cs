using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    
    [SerializeField] private Collider Collider;
    [SerializeField] private string SceneName;
    private bool isTriggered = false;
    private float timer = 0f;
 
    public void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        Debug.Log("Triggered");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
            timer = 0f;
        }
    }

    public void FixedUpdate()
    {
        if (isTriggered)
        {
            SceneManager.instance.GetCanvas().enabled = true;
            SceneManager.instance.GetCanvas().GetComponentInChildren<Slider>().value = timer / 2f;
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                isTriggered = false;
                SceneManager.instance.LoadScene(SceneName);
            }
        }
        else
        {
            SceneManager.instance.GetCanvas().enabled = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        timer = 0f;
    }



}
