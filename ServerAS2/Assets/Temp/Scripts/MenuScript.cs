using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {
    public bool mainManuButton, howToPlayButton, CreditsButton, ExitButton, playButton, SettingsButton, SettingsSound, ScorBoardButton, AppyButton;
    public bool Lv1, Lv2, T1, T2, pused;
    public GameObject pauseMenu;
    public InputField NewName;
    public AudioClip ButtonClick;
    // Use this for initialization
    void Start ()
    {
		//Setting all values to false to stop buttons automatiocaly being pressed
        mainManuButton = false;
        howToPlayButton = false;
        CreditsButton = false;
        ExitButton = false;
        playButton = false;
        ScorBoardButton = false;
        SettingsButton = false;
        SettingsSound = false;
        AppyButton = false;
        Lv1 = false;
        Lv2 = false;
        T1 = false;
        T2 = false;
        pused = false;
    }	
	// Update is called once per frame
	void Update ()
    {
        ClickedPused();
		//Each if statment check to see if the represented button has been pressed and if so then loads the relevent data
        if (Lv1 == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(8);
        }        
        if (Lv2 == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(9);
        }
        if (T1 == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            T2 = false;
        }
        if (T2 == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            T1 = false;
        }
        if (mainManuButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(0);
        }
        if (howToPlayButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(1); 
        }
        if ( CreditsButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(2);
        }
        if (ExitButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            Application.Quit();
            Debug.Log("Exit");
        }
        if (playButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(3);
        }
        if (SettingsButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(4);
        }
        if (ScorBoardButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(5);
        }
        if (SettingsSound == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            SceneManager.LoadScene(6);
        }
        if (AppyButton == true)
        {
            SoundController.instance.playEffectEngin(ButtonClick);
            ScorboardController.instance.ChangeName(NewName.text);
        }
        if (pused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
        if (pauseMenu != null)
            pauseMenu.SetActive(pused);
    }
	//each of these methods are called when the relevent button is clicked and they set the relevent boolean to true
    public void ClickedPlay()
    {
        {
            Time.timeScale = 1.0f;
            pused = !pused;
        }
    }
    public void ClickedPused()
    {
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                pused = !pused;

        }
    }
    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void ClickedExit()
    {
        {
            ExitButton = true;
        }
    }
    public void LevleSelect()
    {
        playButton = true;
    }
    public void ClickedCredits()
    {
        {
            CreditsButton = true;
        }
    }
    public void ClickedHowToPlay()
    {
        {
            howToPlayButton = true;
        }
    }
    public void ClickedMainManu()
    {
        {
            mainManuButton = true;
        }
    }
    public void Apply()
    {
        AppyButton = true;
    }
    public void Lv1Click()
    {
        ScorboardController.instance.setTrack(1);
        Lv1 = true;
    }
    public void Lv2Click()
    {
        ScorboardController.instance.setTrack(2);
        Lv2 = true;
    }
    public void T1Click()
    {
        ScorboardController.instance.setTrack(1);
        T1 = true;
    }
    public void T2Click()
    {
        
        ScorboardController.instance.setTrack(2);
        T2 = true;
    }
    public void ClickedScorBoardButton()
    {
        {
            ScorBoardButton = true;
        }
    }
    public void ClickedSettingsButton()
    {
        {
            SettingsButton = true;
        }
    }
    public void ClickedSound()
    {
        {
            SettingsSound = true;
        }
    }
}
