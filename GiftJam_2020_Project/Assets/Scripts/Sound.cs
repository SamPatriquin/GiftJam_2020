using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{

    [SerializeField] private AudioClip clip;
    public AudioSource source { get; private set; }
    public string name { get; private set; }

    public Sound(AudioSource source) {
        this.source = source;
    }

}
