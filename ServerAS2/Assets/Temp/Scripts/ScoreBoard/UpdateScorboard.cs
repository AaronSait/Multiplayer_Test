using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateScorboard : MonoBehaviour {
    public Text ThierTime, ThierPlace;
    int Place;
    float Time;
    void Start()
    {
        setTime();
        CheckScorboard();
        SetTextFilds();
    }
	// stores the time the player got during there track
    void setTime()
    {
        Time = ScorboardController.instance.GetScoreHolder();
    }
	// this check the playre postion in on the scorebard
    void CheckScorboard()
    {
        Place = ScorboardController.instance.UpdateArray(Time);
    }
    void SetTextFilds()
    {
		// this updated the textfilds with the player positon and time if the player is not on the scoreboard then N/A is displayed
        ThierTime.text = Time.ToString("F2");
        if (Place >= 10)
        {
            ThierPlace.text = "N/A";
        }else
        {
            Place++;
            ThierPlace.text = Place.ToString();
        }
        ScorboardController.instance.Save();
    }
}
