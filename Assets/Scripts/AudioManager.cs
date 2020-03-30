using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]

public class SoundClass
{
    public string name;
    public AudioClip clip;
    [Range(0F, 1F)]
    public float volume;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
    public AudioMixerGroup audioMixerGroup;
}


public class AudioManager : MonoBehaviour
{
    public SoundClass[] sounds;

    void Awake()
    {
        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }

    }

    public void Play(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PlayOnce(AudioClip name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.clip == name);
        s.source.PlayOneShot(name);
    }
}
