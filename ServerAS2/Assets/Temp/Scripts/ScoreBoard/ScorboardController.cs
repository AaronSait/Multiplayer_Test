using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class ScorboardController : MonoBehaviour 
{
    public static ScorboardController instance = null;
    string [] ScorboardName = new string [10];
    float[] ScorboardTime = new float[10];
    string[] ScorboardNameT2 = new string[10];
    float[] ScorboardTimeT2 = new float[10];
    string pathT1 = "C:/AaronPeterSait16433494/ScoreBoardT1.txt";
    string pathT2 = "C:/AaronPeterSait16433494/ScoreBoardT2.txt";
    string dpath = "C:/AaronPeterSait16433494";
    public string[,] ScoreName = new string[10,2];
    float ScoreHolder;
    string Name = "Aaron";
    public int Track = 2;
    public InputField newName;
    // Use this for initialization
    void Awake()
    {
		// this is checking to see if there is curently an instanc of theis scriped and if not it creates one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
		//this is chcking to see if there is currently a folder called AaronSait16433494 on the C drive
        if (!Directory.Exists(dpath))
        {
			//if there is not then a folder is created
            DirectoryInfo di = Directory.CreateDirectory(dpath);
        }
		// this is checking to see if there is a .txt folder calles ScorBardT1 in the directory AaronSait16433494
            if (!File.Exists(pathT1))
            {
				//if ther is not then it creates the .txt file and polulates it
                using (StreamWriter sw = File.CreateText(pathT1))
                {
                    sw.WriteLine("999");
                    sw.WriteLine("1");
                    sw.WriteLine("999");
                    sw.WriteLine("2");
                    sw.WriteLine("999");
                    sw.WriteLine("3");
                    sw.WriteLine("999");
                    sw.WriteLine("4");
                    sw.WriteLine("999");
                    sw.WriteLine("5");
                    sw.WriteLine("999");
                    sw.WriteLine("6");
                    sw.WriteLine("999");
                    sw.WriteLine("7");
                    sw.WriteLine("999");
                    sw.WriteLine("8");
                    sw.WriteLine("999");
                    sw.WriteLine("9");
                    sw.WriteLine("999");
                    sw.WriteLine("10");
                }
            }
			// this is checking to see if there is a .txt folder calles ScorBardT2 in the directory AaronSait16433494
            if (!File.Exists(pathT2))
            {
				//if ther is not then it creates the .txt file and polulates it
                using (StreamWriter sw = File.CreateText(pathT2))
                {
                    sw.WriteLine("999");
                    sw.WriteLine("1");
                    sw.WriteLine("999");
                    sw.WriteLine("2");
                    sw.WriteLine("999");
                    sw.WriteLine("3");
                    sw.WriteLine("999");
                    sw.WriteLine("4");
                    sw.WriteLine("999");
                    sw.WriteLine("5");
                    sw.WriteLine("999");
                    sw.WriteLine("6");
                    sw.WriteLine("999");
                    sw.WriteLine("7");
                    sw.WriteLine("999");
                    sw.WriteLine("8");
                    sw.WriteLine("999");
                    sw.WriteLine("9");
                    sw.WriteLine("999");
                    sw.WriteLine("10");
                }
            }
    }
    private void Start()
    {
		// on start the display array method is called to load the scoreboard
        DisplayArray();
    }
    public void setTrack(int T)
    {
		// this is a holder for what tracks scorbard is to be loaded 
        Track = T;
    }
    public void setScoreHolder(float Score)
    {
		// this is the holder for the scorebard
        ScoreHolder = Score;
    }
    public float GetScoreHolder()
    {
		//this retrns the scorebard to where it was called
        return ScoreHolder;
    }
    public int UpdateArray(float Score)
    {
        string NHolder;
        float THolder;
        string NHolder2;
        float THolder2;
		// this is checking to see what scorebard is to be updated
        if (Track == 1)
        {
			// it then loops throght the scoreboard checkin each time agenst the time the user got
            for (int i = 0; i <= 9; i++)
            {
				// this is checking the users time agenst the time in the scorbard
                if (ScorboardTime[i] > Score || ScorboardTime[i] == 0)
                {
					// if the user came in last place then
                    if (i == 9)
                    {
						//their score and time are saved
                        ScorboardTime[i] = Score;
                        ScorboardName[i] = Name;
						//the save method is then called
                        Save();
                        DisplayArray();
						// the value of i is then returned to where the method was called
                        return i;
                    }
                    else
                    {
						// if the player did not come last
						// this is moving all the other element in the scorboard  down by one element
                        THolder = ScorboardTime[i];
                        NHolder = ScorboardName[i];
                        ScorboardTime[i] = Score;
                        ScorboardName[i] = Name;
                        for (int j = i + 1; j < 9; j++)
                        {
                            THolder2 = ScorboardTime[j];
                            NHolder2 = ScorboardName[j];
                            ScorboardTime[j] = THolder;
                            ScorboardName[j] = NHolder;
                            THolder = THolder2;
                            NHolder = NHolder2;
                        }
                        ScorboardTime[9] = THolder;
                        ScorboardName[9] = NHolder;
						// thsi is then saving the scorbard
                        Save();
                        DisplayArray();
						// the value of i is then returned to where the method was called
                        return i;
                    }
                }
            }
        }else if (Track == 2)
        {
			// it then loops throght the scoreboard checkin each time agenst the time the user got
            for (int i = 0; i <= 9; i++)
            {
				// this is checking the users time agenst the time in the scorbard
                if (ScorboardTimeT2[i] > Score || ScorboardTimeT2[i] == 0)
                {
					// if the user came in last place then
                    if (i == 9)
                    {
						//their score and time are saved
                        ScorboardTimeT2[i] = Score;
                        ScorboardNameT2[i] = Name;
						//the save method is then called
                        Save();
                        DisplayArray();
						// the value of i is then returned to where the method was called
                        return i;
                    }
                    else
                    {
						// if the player did not come last
						// this is moving all the other element in the scorboard  down by one element
                        THolder = ScorboardTimeT2[i];
                        NHolder = ScorboardNameT2[i];
                        ScorboardTimeT2[i] = Score;
                        ScorboardNameT2[i] = Name;
                        for (int j = i + 1; j < 9; j++)
                        {
                            THolder2 = ScorboardTimeT2[j];
                            NHolder2 = ScorboardNameT2[j];
                            ScorboardTimeT2[j] = THolder;
                            ScorboardNameT2[j] = NHolder;
                            THolder = THolder2;
                            NHolder = NHolder2;
                        }
                        ScorboardTimeT2[9] = THolder;
                        ScorboardNameT2[9] = NHolder;
						// thsi is then saving the scorbard
                        Save();
                        DisplayArray();
						// the value of i is then returned to where the method was called
                        return i;
                    }
                }
            }
        }
		// if the user dose not get on the scoarboard then 100 is returned 
        return 100;               
    }    
    public void DisplayArray()
    {
		// this is checking what trake needs to be displayed
        if (Track == 1)
        {
			//the scorbard for th edesierd trake is then loaded into memory
            Load();
			// this data is then stored in to a 2d array to be transered to another scriped
            for (int i = 0; i < 10; i++)
            {
                ScoreName[i,0] = ScorboardTime[i].ToString("F2");
                ScoreName[i,1] = ScorboardName[i];
            }
        }else if (Track == 2)
        {
			//the scorbard for th edesierd trake is then loaded into memory
            Load();
			// this data is then stored in to a 2d array to be transered to another scriped
            for (int i = 0; i < 10; i++)
            {
                ScoreName[i,0] = ScorboardTimeT2[i].ToString("F2");
                ScoreName[i,1] = ScorboardNameT2[i];
            }
        }
    }
    public void Save ()
    {
		// this is checking what trake needs to be Saved
        if (Track == 1)
        {
			// a stream writer is then created pointing to the correct path
            StreamWriter Write = new StreamWriter(pathT1);
			// looping throgh the arrays each index is then converted to a string and saved to the text file
            for (int i = 0; i < 10; i++)
            {
                Write.WriteLine(ScorboardTime[i].ToString());
                Write.WriteLine(ScorboardName[i]);
            }
			//the stream writer is then closed
            Write.Close();
        } else if (Track ==2)
        {
			// a stream writer is then created pointing to the correct path
            StreamWriter Write = new StreamWriter(pathT2);
			// a stream writer is then created pointing to the correct path
            for (int i = 0; i < 10; i++)
            {
                Write.WriteLine(ScorboardTimeT2[i].ToString());
                Write.WriteLine(ScorboardNameT2[i]);
            }
			//the stream writer is then closed
            Write.Close();
        }
    }
    void Load()
    {
		// this is checking what trake needs to be Loaded
        if (Track == 1)
        {
			// a stream reader is then created pointing to the correct path
            StreamReader reader = new StreamReader(pathT1);
            // the two arrayes are then populated and the data is converted to the corect datatype
			for (int i = 0; i < 10; i++)
            {
                ScorboardTime[i] = float.Parse(reader.ReadLine());
                ScorboardName[i] = reader.ReadLine();
            }
			//the stream reader is then closed
            reader.Close();
        } else if (Track ==2)
        {
			// a stream reader is then created pointing to the correct path
            StreamReader reader = new StreamReader(pathT2);
			// the two arrayes are then populated and the data is converted to the corect datatype
            for (int i = 0; i < 10; i++)
            {
                ScorboardTimeT2[i] = float.Parse(reader.ReadLine());
                ScorboardNameT2[i] = reader.ReadLine();
            }
			//the stream reader is then closed
            reader.Close();
        }
    }
	// this changes the name to be displayed on the scorboardrd
    public void ChangeName(string NewName)
    {
        Name = NewName;
    }
}
