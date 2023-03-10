using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private Canvas Canvas;
    [SerializeField] private GameObject FadeScreenPrefab;

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
        Canvas.enabled = false;
        this.Canvas.worldCamera = Camera.main;
        DontDestroyOnLoad(Canvas);
    }

    public void Start(){
        if(Camera.main.GetComponentInChildren<FadeScreen>() == null){
            GameObject fadeScreen = Instantiate(FadeScreenPrefab, Camera.main.transform);
            fadeScreen.transform.localPosition = new Vector3(0f, 0f, 0.05f);
            fadeScreen.transform.localRotation = new Quaternion(90f, 0f, 0f, 0f);
        }
        Camera.main.GetComponentInChildren<FadeScreen>().FadeIn();
    }

    public void FixedUpdate(){
        Canvas.transform.position = Camera.main.transform.forward * 0.8f + Camera.main.transform.position;
        Canvas.transform.rotation = Camera.main.transform.rotation;
    }

    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    public IEnumerator LoadSceneRoutine(string sceneName)
    {
        Canvas.enabled = false;
        Camera.main.GetComponentInChildren<FadeScreen>().FadeOut();
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("Menu");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Ambiance_0");
        Camera.main.GetComponentInChildren<FadeScreen>().FadeIn();
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

    public Canvas GetCanvas()
    {
        return Canvas;
    }

}
