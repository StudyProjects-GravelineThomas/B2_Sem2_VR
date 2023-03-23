using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public new string name;

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    [SerializeField]
    [Tooltip("If true, an icon of the virtual assistant wiil be shown on screen")]
    public bool isOneSpaking;

    [HideInInspector]
    public AudioSource audioSource;

}
