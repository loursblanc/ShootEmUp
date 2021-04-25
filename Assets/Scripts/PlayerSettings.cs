using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayersSettings
{
    public delegate void VolumeChange(float volume);

    static public event VolumeChange MusicVolumeChanged;
    static public float MusicVolume
    {
        get { return PlayerPrefs.GetFloat("MusicVolume", 0.8f); }
        set
        {
            PlayerPrefs.SetFloat("MusicVolume", value);
            if (MusicVolumeChanged != null)
                MusicVolumeChanged(value);
        }
    }

    static public event VolumeChange SFXVolumeChanged;
    static public float SFXVolume
    {
        get { return PlayerPrefs.GetFloat("SFXVolume", 0.4f); }
        set
        {
            PlayerPrefs.SetFloat("SFXVolume", value);
            if (SFXVolumeChanged != null)
                SFXVolumeChanged(value);
        }
    }
}
