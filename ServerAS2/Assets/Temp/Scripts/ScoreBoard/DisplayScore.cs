using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour 
{
    public Text No1, No2, No3, No4, No5, No6, No7, No8, No9, No10;
    public Text No1N, No2N, No3N, No4N, No5N, No6N, No7N, No8N, No9N, No10N;	
	// Update is called once per frame
	void Update () 
	{
		//this first calles the Display Array method in the Scorbard Controller
        ScorboardController.instance.DisplayArray();
		//This assines the return value to an array
        string[,] Scorbard = ScorboardController.instance.ScoreName;
		//updating text filds to hold the correct score
        No1.text = Scorbard[0,0] + "";
        No2.text = Scorbard[1,0] + "";
        No3.text = Scorbard[2,0] + "";
        No4.text = Scorbard[3,0] + "";
        No5.text = Scorbard[4,0] + "";
        No6.text = Scorbard[5,0] + "";
        No7.text = Scorbard[6,0] + "";
        No8.text = Scorbard[7,0] + "";
        No9.text = Scorbard[8,0] + "";
        No10.text = Scorbard[9,0] + "";
        No1N.text = Scorbard[0, 1] + "";
        No2N.text = Scorbard[1, 1] + "";
        No3N.text = Scorbard[2, 1] + "";
        No4N.text = Scorbard[3, 1] + "";
        No5N.text = Scorbard[4, 1] + "";
        No6N.text = Scorbard[5, 1] + "";
        No7N.text = Scorbard[6, 1] + "";
        No8N.text = Scorbard[7, 1] + "";
        No9N.text = Scorbard[8, 1] + "";
        No10N.text = Scorbard[9, 1] + "";
    }
}
