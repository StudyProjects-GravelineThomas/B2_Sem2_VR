using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{

    private Renderer rend;
    private float fadeDuration = 0.75f;
    private float alpha = 0f;

    public void FadeIn(){
        StartCoroutine(FadeRoutine(1f, 0f));
    }

    public void FadeOut(){
        StartCoroutine(FadeRoutine(0f, 1f));
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut){
        float timer = 0f;
        while (timer < fadeDuration){
            timer += Time.deltaTime;
            alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        yield return null;
        
    }
}
