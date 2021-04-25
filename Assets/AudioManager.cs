using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MusicVolume", PlayersSettings.MusicVolume.LinearToDecibel());
        mixer.SetFloat("SFXVolume", PlayersSettings.SFXVolume.LinearToDecibel());

        PlayersSettings.MusicVolumeChanged += delegate (float volume)
        {
            mixer.SetFloat("MusicVolume", volume.LinearToDecibel());
        };
        PlayersSettings.SFXVolumeChanged += delegate (float volume)
        {
            mixer.SetFloat("SFXVolume", volume.LinearToDecibel());
        };
    }
}
