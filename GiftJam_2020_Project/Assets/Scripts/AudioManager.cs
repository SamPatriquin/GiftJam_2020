using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private Dictionary<string, Sound> soundDict = new Dictionary<string, Sound>();
    public string currentMusic { get; set; }

    private void Awake() {
        foreach (Sound sound in sounds) {
            sound.source = this.gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.isLoop;
            soundDict.Add(sound.clip.name, sound);
        }
    }

    public void PlaySound(string name, GameObject caller) {
        try {
            AudioSource source = soundDict[name].source;
            soundDict[name].source.Play();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void PlaySoundLoop(string name, GameObject caller) {
        try {
            AudioSource source = soundDict[name].source;
            source.loop = true;
            source.Play();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void PlayOneShotSound(string name, GameObject caller) {
        try {
            AudioSource source = soundDict[name].source;
            source.PlayOneShot(soundDict[name].source.clip);
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }

    public void StopSound(string name, GameObject caller) {
        try {
            AudioSource source = soundDict[name].source;
            source.Stop();
        }
        catch { Debug.LogError("AudioManager does not reference a clip with name: " + name + ", called by: " + caller); }
    }
}
