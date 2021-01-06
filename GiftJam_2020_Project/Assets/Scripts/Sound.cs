using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound {

    [SerializeField] public AudioClip clip;
    [SerializeField] [Range(0.0f, 1.0f)] public float volume = 0f;
    [SerializeField] public bool isLoop  = false;
    public AudioSource source;
}
