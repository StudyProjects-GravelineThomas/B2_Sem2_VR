using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField]
    private Canvas oneCanvas;

    public static AudioManager instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(oneCanvas);
        oneCanvas.enabled = false;
        

        foreach(Sound _sound in sounds){
            _sound.audioSource = gameObject.AddComponent<AudioSource>();
            _sound.audioSource.clip = _sound.clip;
            _sound.audioSource.volume = _sound.volume;
            _sound.audioSource.pitch = _sound.pitch;
            _sound.audioSource.loop = _sound.loop;
        }
    }

    public void FixedUpdate(){
        oneCanvas.worldCamera = Camera.main;
        oneCanvas.planeDistance = 0.5f;
        bool _showOneSpeaking = false;
        foreach(Sound sound in sounds){
            if(sound.audioSource.isPlaying && sound.isOneSpaking) _showOneSpeaking = true;
        }
        if(_showOneSpeaking){
            oneCanvas.enabled = true;
        } else {
            oneCanvas.enabled = false;
        }
    }

    public void PlaySound(string name){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) return;
        _sound.audioSource.Play();
    }

    public void StopSound(string name){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) return;
        _sound.audioSource.Stop();
    }

    public void StopAllSounds(){
        foreach(Sound s in sounds){
            s.audioSource.Stop();
        }
    }

    public void PauseSound(string name){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) return;
        _sound.audioSource.Pause();
    }

    public void ResumeSound(string name){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) return;
        _sound.audioSource.UnPause();
    }

    public void DeathPlay(){
        StopAllSounds();
    }

    public Sound getSound(string name){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        return _sound;
    }
}
