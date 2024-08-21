using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider myMasterSlider, myMusikSlider, mySFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        SetMasterVolume();
        SetMusikVolume();
        SetSFXValume();
    }
    public void SetMasterVolume()
    {
        float temp = myMasterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(temp) * 20);
    }
    public void SetMusikVolume()
    {
        float temp1 = myMusikSlider.value;
        myMixer.SetFloat("Musik", Mathf.Log10(temp1) * 20);
    }
    public void SetSFXValume()
    {
        float temp2 = mySFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(temp2) * 20);
    }

    
}
