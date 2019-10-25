using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour {

    public AudioMixer audiomixer;

    public void Start()
    {
        SetVolume(10f);
    }
  
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("vol", volume);
    }
}
