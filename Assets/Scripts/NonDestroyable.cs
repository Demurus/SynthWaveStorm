using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NonDestroyable : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    void Start()
    {
        
        
    }

    private void Awake()
    {
       
        GameObject[] objects = GameObject.FindGameObjectsWithTag("BackGroundMusic");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void UnmuteMusic()
    {
        audioMixer.SetFloat("musicVolume", -13.0F);
    }

    public void MuteMusic()
    {
        audioMixer.SetFloat("musicVolume", -80.0F);
    }
}
