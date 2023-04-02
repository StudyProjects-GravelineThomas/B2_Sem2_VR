using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField]
    private Canvas oneCanvas;
    private List<Sound> soundsPlaying = new List<Sound>();

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
            if(sound.audioSource.isPlaying && !soundsPlaying.Contains(sound)) soundsPlaying.Add(sound);
            if(sound.audioSource.isPlaying && sound.isOneSpaking) _showOneSpeaking = true;
        }
        if(_showOneSpeaking){
            oneCanvas.enabled = true;
            // foreach(Sound sound in sounds){
            //     if(sound.isOneSpaking) return;
            //     sound.audioSource.volume = sound.volume / 3;
            // }
        } else {
            oneCanvas.enabled = false;
        }
    }

    public void Update(){
        foreach(Sound sound in sounds){
            // Debug.Log("sound " + sound.name + " is playing: " + sound.audioSource.time+"/"+sound.audioSource.clip.length);
            if((sound.audioSource.isPlaying && sound.audioSource.time >= sound.audioSource.clip.length) || (soundsPlaying.Contains(sound) && !sound.audioSource.isPlaying)){
                if(soundsPlaying.Contains(sound)) soundsPlaying.Remove(sound);
                // Debug.Log("sound " + sound.name + " finished playing");
                if(sound.followUpSoundName != ""){
                    // Debug.Log("sound " + sound.name + " has follow up sound " + sound.followUpSoundName);
                    PlaySoundAfter(sound.followUpSoundName, 1f);
                }
            }
        }
    }

    public void PlaySoundAfter(string name, float seconds){
        StartCoroutine(PlaySoundAfterEnumerator(name, seconds));
    }

    public IEnumerator PlaySoundAfterEnumerator(string name, float seconds){
        yield return new WaitForSeconds(seconds);
        PlaySound(name);
    }

    public IEnumerator ChangeVolumeSmoothly(string name, float seconds, float targetVolume){
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) yield break;
        float _initialVolume = _sound.audioSource.volume;
        float _time = 0f;
        while(_time < seconds){
            _time += Time.deltaTime;
            _sound.audioSource.volume = Mathf.Lerp(_initialVolume, targetVolume, _time/seconds);
            yield return null;
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
