using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] Sound[] _sounds;

    private Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();

    // Start is called before the first frame update
    void Awake(){
        AudioManager[] objs = FindObjectsOfType<AudioManager>();
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        foreach (AudioClip clip in clips) {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            Sound sound = new Sound(source);
            sounds.Add(clip.name, sound);
        }
    }

    public void PlaySound(string name, GameObject caller) {
        try {
            AudioSource source = sounds[name].source;
            sounds[name].source.loop = false;
            sounds[name].source.Play();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void PlaySoundLoop(string name, GameObject caller) {
        try {
            AudioSource source = sounds[name].source;
            source.loop = true;
            source.Play();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void PlayOneShotSound(string name, GameObject caller) {
        try {
            AudioSource source = sounds[name].source;
            source.PlayOneShot(sounds[name].source.clip);
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void StopSound(string name, GameObject caller) {
        try {
            AudioSource source = sounds[name].source;
            source.Stop();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }
}
