using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundController : MonoBehaviour
{
    public AudioSource SFXE;
    public AudioSource SFXB;
    public AudioSource main;
    public static SoundController instance = null;
    // Use this for initialization
    void Awake()
    {
		//checks to see if this scriped is already an instance and if not then creates an instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	// this method playes the engin nose effect
    public void playEffectEngin(AudioClip Sound)
    {
		//this is checking to see if a sound is currently playing and if it is not then it playes the engin sound
        if (!SFXE.isPlaying)
        {
            SFXE.clip = Sound;
            SFXE.Play();
        }        
    }
	// this method playes the Breaks noise effect
    public void playEffectBrakes(AudioClip Sound)
    {
		//this is checking to see if a sound is currently playing and if it is not then it playes the Breaks sound
        if (!SFXB.isPlaying)
        {
            SFXB.clip = Sound;
            SFXB.Play();
        }
    }
    private void Update()
    {
		//this stopes the sound effects if they have been playing for more than half a second
        if (SFXE.time == 0.5f)
        {
            SFXE.Stop();
        }
        if (SFXB.time == 0.5f)
        {
            SFXB.Stop();
        }
    }
    public float GetMainVolume()
    {
		//this returns the volume of main
        return main.volume;
    }
    public float GetSFXVolume()
    {
		//this returns the volume of the sound effects
        return SFXE.volume;
    }
    public void changeVolume(float MainVol, float SFXVol)
    {
		//this updates the volume of the main music and the SFX to what the user wants
        SFXE.volume = SFXVol;
        SFXB.volume = SFXVol;
        main.volume = MainVol;
    } 
}
