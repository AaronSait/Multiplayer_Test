using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{ 
    public Slider MainVolume, SFXVolume;
    public Text MainVolumeCurrent, SFXVolumeCurrent;
    // Use this for initialization
	// the sliders values are set to the current volume of the audio sources
    void Start()
    {
        MainVolume.value = SoundController.instance.GetMainVolume() * 100;
        SFXVolume.value = SoundController.instance.GetSFXVolume() * 100;
    }
    // Update is called once per frame
    void Update () 
	{
		//this changes the volumes based on the value of the slides
        SoundController.instance.changeVolume((MainVolume.value/100), (SFXVolume.value/100));
        SFXVolumeCurrent.text = SFXVolume.value + "%";
        MainVolumeCurrent.text = MainVolume.value + "%";
    }
}
