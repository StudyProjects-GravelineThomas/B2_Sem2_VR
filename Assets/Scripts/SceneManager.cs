using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("Menu");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Ambiance_0");
    }

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("Menu");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Ambiance_0");
    }

    public void LoadSceneAdditive(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void LoadSceneAdditive(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
    }

    public void UnloadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex);
    }

}
