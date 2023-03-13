using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private Canvas Canvas;
    [SerializeField] private Canvas FadeScreenCanvas;
    [SerializeField] private GameObject FadeScreenPrefab;

    private string sceneToSwitchTo;
    private float timer;

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
        DontDestroyOnLoad(FadeScreenCanvas);
    }

    public void FixedUpdate(){
        if(FadeScreenCanvas.worldCamera == null) FadeScreenCanvas.worldCamera = Camera.main;
        FadeScreenCanvas.planeDistance = 0.05f;
        Canvas.transform.position = Camera.main.transform.forward * 0.8f + Camera.main.transform.position;
        Canvas.transform.rotation = Camera.main.transform.rotation;
        if(sceneToSwitchTo != null){
            timer -= Time.deltaTime;
            FadeScreenCanvas.GetComponentInChildren<Image>().color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, timer-1f / 2f));
            AudioManager.instance.getSound("Menu").audioSource.volume = Mathf.Lerp(0f, AudioManager.instance.getSound("Menu").volume, timer / 2.5f);
            AudioManager.instance.getSound("Ambiance_0").audioSource.volume = Mathf.Lerp(0f, AudioManager.instance.getSound("Ambiance_0").volume, timer / 2.5f);
            if(timer <= 0f){
                AudioManager.instance.StopAllSounds();
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToSwitchTo);
                AudioManager.instance.getSound("Ambiance_0").audioSource.volume = 0;
                AudioManager.instance.PlaySound("Ambiance_0");

                sceneToSwitchTo = null;
                timer = 3f;
            }
        } else {
            if(timer > 0f){
                timer -= Time.deltaTime;
                FadeScreenCanvas.GetComponentInChildren<Image>().color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, timer / 3f));
                AudioManager.instance.getSound("Ambiance_0").audioSource.volume = Mathf.Lerp(AudioManager.instance.getSound("Ambiance_0").volume, 0f, timer / 2.5f);
                AudioManager.instance.getSound("Menu").audioSource.volume = Mathf.Lerp(AudioManager.instance.getSound("Menu").volume, 0f, timer / 2.5f);
            }
        }
    }

    public void Start(){
        //if(Camera.main.GetComponentInChildren<FadeScreen>() == null){
        //    GameObject fadeScreen = Instantiate(FadeScreenPrefab, Camera.main.transform);
        //    fadeScreen.transform.localPosition = new Vector3(0f, 0f, 0.05f);
        //    fadeScreen.transform.localRotation = new Quaternion(90f, 0f, 0f, 0f);
        //}
        //Camera.main.GetComponentInChildren<FadeScreen>().FadeIn();
        FadeScreenCanvas.GetComponentInChildren<Image>().color = new Color(0f, 0f, 0f, 0f);
        FadeScreenCanvas.worldCamera = Camera.main;
        FadeScreenCanvas.planeDistance = 0.05f;
        AudioManager.instance.getSound("Menu").audioSource.volume = 0f;
        this.timer = 3f;
    }

    
    public void LoadScene(string sceneName)
    {
        this.sceneToSwitchTo = sceneName;
        this.timer = 2.5f;
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
