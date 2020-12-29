using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
    public Text StopWatch;
    float seconds = 0.0f;
    int lap = 0;
    // Update is called once per frame
    void Update ()
    {
		//this is updating the second variable with by 0.01
        seconds += Time.deltaTime;
		//this is updating a texfild
        StopWatch.text = seconds.ToString("F2");
        
	}
    public void GetTime()
    {
		//checking to see if the playre is finshing a lap
        if (lap == 1)
        {
			//this stops the stopwach and saves it in the scoarbard controller then loads the game over screen
            seconds = float.Parse(StopWatch.text);
            ScorboardController.instance.setScoreHolder(seconds);
            SceneManager.LoadScene(7);
            lap++;
        }
        else
        {
			// if the player has not finished then lap is incremented
            lap++;
        }
    }
}
